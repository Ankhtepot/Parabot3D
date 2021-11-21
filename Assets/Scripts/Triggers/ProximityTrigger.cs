using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Triggers
{
    public class ProximityTrigger : MonoBehaviour
    {
        public UnityEvent OnEnterIntoProximity;
        public UnityEvent OnExitOutOfDistance;
        public UnityEvent OnStayInProximity;
    
#if UNITY_EDITOR
        [SerializeField] private bool showDebugMessages;
#endif
        [SerializeField] private List<string> AcceptedTags = new List<string>();

        private void OnTriggerEnter(Collider other) {
            triggerEventOnAcceptedTag(other.tag, () => OnEnterIntoProximity?.Invoke(), "Enter");
        }

        private void OnTriggerExit(Collider other) {
            triggerEventOnAcceptedTag(other.tag, () => OnExitOutOfDistance?.Invoke(), "Exit");
        }

        private void OnTriggerStay(Collider other) {
            triggerEventOnAcceptedTag(other.tag, () => OnStayInProximity?.Invoke(), "Stay");
        }

        private void triggerEventOnAcceptedTag(string tagOfTheOther, Action action, string messageText = "")
        {
            if (!AcceptedTags.Contains(tagOfTheOther)) return;
        
#if UNITY_EDITOR
            if (showDebugMessages && !string.IsNullOrEmpty(messageText))
            {
                print("Accepted tag trigger fired on: " + messageText);
            }
#endif
        
            action();
        }
    }
}
