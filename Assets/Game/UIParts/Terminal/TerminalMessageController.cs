using Attributes;
using ScriptableObjects;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Game.UIParts.Terminal
{
    public class TerminalMessageController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI fromTMP;
        [SerializeField] private TextMeshProUGUI toTMP;
        [SerializeField] private TextMeshProUGUI messageTMP;

        public void Set(string from, string to, string message)
        {
            fromTMP.text = from;
            toTMP.text = to;
            messageTMP.text = message;
        }
    }
}