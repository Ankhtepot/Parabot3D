using System;
using System.Collections.Generic;
using System.Linq;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI_parts.Terminal
{
    public class TerminalController : MonoBehaviour
    {
        [SerializeField] private GameObject rootCanvas;
        [SerializeField] private GameObject mainMenuPage;
        [SerializeField] private GameObject operationsPage;
        [SerializeField] private GameObject operationsButtonWrapper;
        [SerializeField] private Button operationsButton;

        private List<TerminalActionSetup> settings;
        private List<TerminalActionSetup> operations;
        private void OnEnable()
        {
            EventBroker.OnTerminalInvoked += InvokeTerminal;
            EventBroker.OnTerminalDismissed += DismissTerminal;
            settings = new List<TerminalActionSetup>();
            operations = new List<TerminalActionSetup>();
            rootCanvas.SetActive(false);
        }

        private void InvokeTerminal(IEnumerable<TerminalActionSetup> newSettings)
        {
            if (newSettings == null) return;
            
            settings = newSettings.Where(setting => setting.actionType != ETerminalActionType.None).ToList();

            if (!settings.Any()) return;

            SetupTerminal();
        }

        private void SetupTerminal()
        {
            rootCanvas.SetActive(true);

            int actionTypesCount = 0;
            operations = settings.Where(setting => setting.actionType == ETerminalActionType.Operation).ToList();
            if (operations.Count > 0) actionTypesCount += 1;

            if (actionTypesCount == 1)
            {
                if (operations.Count > 0) OpenOperationsPage();
                return;
            }
            
            operationsButtonWrapper.SetActive(settings.Any(setting => setting.actionType == ETerminalActionType.Operation));
        }

        private void OpenOperationsPage()
        {
            mainMenuPage.SetActive(false);
            operationsPage.SetActive(true);
            Debug.Log($"Registered {operations.Count} operations.");
        }

        private void DismissTerminal()
        {
            settings.Clear();
            operations.Clear();
            operationsButtonWrapper.SetActive(false);
            rootCanvas.SetActive(false);
        }

        private void OnDisable()
        {
            EventBroker.OnTerminalInvoked -= InvokeTerminal;
            EventBroker.OnTerminalDismissed -= DismissTerminal;
        }
    }
}