using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.UIParts
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] private LabelText labelText;
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI labelTMP;

        private void Awake()
        {
            labelTMP.text = labelText.Text;
        }

        public void OnClickAddListener(UnityAction onClick)
        {
            button.onClick.AddListener(onClick);
        }

        public void OnClickRemoveListener(UnityAction onClick)
        {
            button.onClick?.RemoveListener(onClick);
        }
    }
}
