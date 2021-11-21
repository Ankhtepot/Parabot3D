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

        public void Set(TerminalActionSetup newSetting)
        {
            var setting = newSetting.messageOperationSetting;
            fromTMP.text = setting.messageFrom.Text;
            toTMP.text = setting.messageTo.Text;
            messageTMP.text = setting.messageText.Text;
            fromLabelTMP.text = fromLabelText.Text;
            toLabelTMP.text = toLabelText.Text;
            messageLabelTMP.text = messageLabelText.Text;
        }
    }
}