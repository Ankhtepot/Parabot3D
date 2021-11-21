using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using Services;
using UnityEngine;
using Utilities.ObjectPool;

namespace Game.UIParts.Terminal
{
    public class TerminalController : MonoBehaviour
    {
        [SerializeField] private GameObject rootCanvas;
        [SerializeField] private Pages pages;
        [SerializeField] private MainPageSetup mainPage;
        [SerializeField] private MessagesPageSetup messagesPage;
        [SerializeField] private OperationsPageSetup operationsPage;

        private Dictionary<string, GameObject> pagesLookout = new Dictionary<string, GameObject>();
        private List<TerminalActionSetup> operations;
        private List<TerminalActionSetup> messages;
        private ObjectPool pool;
        private bool initialInvoke;

        private void Awake()
        {
            pagesLookout = new Dictionary<string, GameObject>
            {
                { pages.MainPageName, pages.mainMenuPage },
                { pages.MessagesPageName, pages.messagesPage },
                { pages.OperationsPageName, pages.operationsPage },
            };
        }

        private void OnEnable()
        {
            EventBroker.OnTerminalInvoked += InvokeTerminal;
            EventBroker.OnTerminalDismissed += DismissTerminal;
            operations = new List<TerminalActionSetup>();
            messages = new List<TerminalActionSetup>();
            rootCanvas.SetActive(false);

            mainPage.messagesButton.OnClickAddListener(OpenMessagesPage);
            mainPage.operationsButton.OnClickAddListener(OpenOperationsPage);
            mainPage.ExitButton.OnClickAddListener(DismissTerminal);
            messagesPage.backButton.OnClickAddListener(SetupTerminal);
            operationsPage.backButton.OnClickAddListener(SetupTerminal);
        }

        private void Start()
        {
            pool = GameController.ObjectPool;
        }

        private void InvokeTerminal(IEnumerable<TerminalActionSetup> newSettings)
        {
            if (newSettings == null) return;

            foreach (var setting in newSettings)
            {
                switch (setting.actionType)
                {
                    case ETerminalActionType.None:
                        break;
                    case ETerminalActionType.Message:
                        messages.Add(setting);
                        break;
                    case ETerminalActionType.Operation:
                        operations.Add(setting);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            if (!operations.Any() && !messages.Any()) return;

            initialInvoke = true;
            SetupTerminal();
        }

        private void SetupTerminal()
        {
            rootCanvas.SetActive(true);

            ActivatePage(pages.MainPageName);

            if (initialInvoke)
            {
                InitialInvokeSetup();
                initialInvoke = false;
                return;
            }

            mainPage.messagesButton.gameObject.SetActive(messages.Any());
            mainPage.operationsButton.gameObject.SetActive(operations.Any());
        }

        private void InitialInvokeSetup()
        {
            int actionTypesCount = 0;
            if (messages.Count > 0) actionTypesCount += 1;
            if (operations.Count > 0) actionTypesCount += 1;

            if (actionTypesCount == 1)
            {
                if (messages.Count > 0) OpenMessagesPage();
                if (operations.Count > 0) OpenOperationsPage();
            }
        }

        private void OpenMessagesPage()
        {
            ActivatePage(pages.MessagesPageName);

            messagesPage.content.RemoveChildren();

            messages.ForEach(message =>
            {
                // var newMessage = pool.GetFromPool(
                //         messagesPage.messagePrefab,
                //         Vector3Extensions.Zero,
                //         Quaternion.identity,
                //         messagesPage.content.gameObject)
                //     .GetComponent(typeof(TerminalMessageController)) as TerminalMessageController;
                var newMessage = SpawnItem<TerminalMessageController>(messagesPage.messagePrefab, messagesPage.content);

                newMessage!.Set(message);
            });
        }

        private void OpenOperationsPage()
        {
            ActivatePage(pages.OperationsPageName);

            operationsPage.content.RemoveChildren();

            operations.ForEach(operation =>
            {
                if (operation.operationType == ETerminalOperationType.OpenDoor)
                {
                    var newDoorOp = SpawnItem<DoorsOperationItemController>(operationsPage.doorOperationPrefab, operationsPage.content);

                    newDoorOp!.Set(operation);
                }
            });
        }

        private T SpawnItem<T>(GameObject item, Component parent) where T : Component
        {
            return pool.GetFromPool(
                           item,
                           Vector3Extensions.Zero,
                           Quaternion.identity,
                           parent.gameObject)
                       .GetComponent(typeof(T)) as T
                   ?? throw new ArgumentException($"GO: {item.name} does not have component of type {typeof(T).Name}.");
        }

        private void ActivatePage(string pageName)
        {
            foreach (var key in pagesLookout.Keys)
            {
                pagesLookout[key].SetActive(key == pageName);
            }
        }

        private void DismissTerminal()
        {
            if (!rootCanvas.activeSelf) return;

            operations.Clear();
            messages.Clear();
            ActivatePage(pages.OperationsPageName);
            rootCanvas.SetActive(false);
        }

        private void OnDisable()
        {
            EventBroker.OnTerminalInvoked -= InvokeTerminal;
            EventBroker.OnTerminalDismissed -= DismissTerminal;

            mainPage.messagesButton.OnClickRemoveListener(OpenMessagesPage);
            mainPage.operationsButton.OnClickRemoveListener(OpenOperationsPage);
            mainPage.ExitButton.OnClickRemoveListener(DismissTerminal);
            messagesPage.backButton.OnClickRemoveListener(SetupTerminal);
            operationsPage.backButton.OnClickRemoveListener(SetupTerminal);
        }

        [Serializable]
        private class Pages
        {
            public GameObject mainMenuPage;
            public GameObject messagesPage;
            public GameObject operationsPage;

            public string MainPageName => mainMenuPage.name;
            public string MessagesPageName => messagesPage.name;
            public string OperationsPageName => operationsPage.name;
        }

        [Serializable]
        private class MainPageSetup
        {
            public ButtonController messagesButton;
            public ButtonController operationsButton;
            public ButtonController ExitButton;
        }

        [Serializable]
        private class MessagesPageSetup
        {
            public Transform content;
            public ButtonController backButton;
            public GameObject messagePrefab;
        }

        [Serializable]
        private class OperationsPageSetup
        {
            public Transform content;
            public ButtonController backButton;
            public GameObject doorOperationPrefab;
        }
    }
}