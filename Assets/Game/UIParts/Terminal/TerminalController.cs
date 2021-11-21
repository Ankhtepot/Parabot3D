using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using Services;
using UnityEngine;
using UnityEngine.UI;
using Utilities.ObjectPool;

namespace Game.UIParts.Terminal
{
    public class TerminalController : MonoBehaviour
    {
        [SerializeField] private GameObject rootCanvas;
        [Header("Pages")]
        [SerializeField] private GameObject mainMenuPage;
        [SerializeField] private GameObject messagesPage;
        [SerializeField] private GameObject operationsPage;
        [Header("Main page")]
        [SerializeField] private GameObject messagesButtonWrapper;
        [SerializeField] private Button messagesButton;
        [SerializeField] private GameObject operationsButtonWrapper;
        [SerializeField] private Button operationsButton;
        [SerializeField] private Button ExitButton;
        [Header("Messages Page")]
        [SerializeField] private Transform messagesContent;
        [SerializeField] private GameObject terminalMessagePrefab;

        private List<TerminalActionSetup> operations;
        private List<TerminalActionSetup> messages;
        private ObjectPool pool;
        
        private void OnEnable()
        {
            EventBroker.OnTerminalInvoked += InvokeTerminal;
            EventBroker.OnTerminalDismissed += DismissTerminal;
            operations = new List<TerminalActionSetup>();
            messages = new List<TerminalActionSetup>();
            rootCanvas.SetActive(false);
            
            messagesButton.onClick.AddListener(OpenMessagesPage);
            operationsButton.onClick.AddListener(OpenOperationsPage);
            ExitButton.onClick.AddListener(DismissTerminal);
        }

        private void Start()
        {
            pool = GameController.ObjectPool;
        }

        private void InvokeTerminal(IEnumerable<TerminalActionSetup> newSettings)
        {
            if (newSettings == null) return;

            foreach(var setting in newSettings)
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

            SetupTerminal();
        }

        private void SetupTerminal()
        {
            rootCanvas.SetActive(true);

            int actionTypesCount = 0;
            if (messages.Count > 0) actionTypesCount += 1;
            if (operations.Count > 0) actionTypesCount += 1;

            if (actionTypesCount == 1)
            {
                if (messages.Count > 0) OpenMessagesPage();
                if (operations.Count > 0) OpenOperationsPage();
                return;
            }
            
            messagesButtonWrapper.SetActive(messages.Any());
            operationsButtonWrapper.SetActive(operations.Any());
        }

        private void OpenMessagesPage()
        {
            Debug.Log("Opening Terminal Messages Page");
            mainMenuPage.SetActive(false);
            messagesPage.SetActive(true);
            operationsPage.SetActive(false);

            messagesContent.RemoveChildren();
            
            messages.ForEach(message =>
            {
                var newMessage = pool.GetFromPool(
                    terminalMessagePrefab,
                    Vector3Extensions.Zero,
                    Quaternion.identity,
                    messagesContent.gameObject)
                    .GetComponent(typeof(TerminalMessageController)) as TerminalMessageController;
                
                newMessage!.Set(message.messageFrom.Text, message.messageTo.Text, message.messageText.Text);
            });
            Debug.Log($"Registered {operations.Count} operations.");
        }

        private void OpenOperationsPage()
        {
            mainMenuPage.SetActive(false);
            messagesPage.SetActive(false);
            operationsPage.SetActive(true);
            Debug.Log($"Registered {operations.Count} operations.");
        }

        private void DismissTerminal()
        {
            if (!rootCanvas.activeSelf) return;
            
            operations.Clear();
            messages.Clear();
            operationsButtonWrapper.SetActive(false);
            mainMenuPage.SetActive(true);
            messagesPage.SetActive(false);
            operationsPage.SetActive(false);
            rootCanvas.SetActive(false);
        }

        private void OnDisable()
        {
            EventBroker.OnTerminalInvoked -= InvokeTerminal;
            EventBroker.OnTerminalDismissed -= DismissTerminal;
            
            messagesButton.onClick.RemoveListener(OpenMessagesPage);
            operationsButton.onClick.RemoveListener(OpenOperationsPage);
            ExitButton.onClick.RemoveListener(DismissTerminal);
        }
    }
}