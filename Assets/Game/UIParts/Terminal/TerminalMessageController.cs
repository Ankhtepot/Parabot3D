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
        [SerializeField] private TextMeshProUGUI fromLabelTMP;
        [SerializeField] private TextMeshProUGUI toLabelTMP;
        [SerializeField] private TextMeshProUGUI messageLabelTMP;
        [SerializeField] private LabelText fromLabelText;
        [SerializeField] private LabelText toLabelText;
        [SerializeField] private LabelText messageLabelText;

        public void Set(string from, string to, string message)
        {
            fromTMP.text = from;
            toTMP.text = to;
            messageTMP.text = message;
            fromLabelTMP.text = fromLabelText.Text;
            toLabelTMP.text = toLabelText.Text;
            messageLabelTMP.text = messageLabelText.Text;
        }
    }
}