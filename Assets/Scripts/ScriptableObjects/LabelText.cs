using UnityEngine;
using static Texts.Labels;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Provided Text", menuName = "ScriptableObjects/labelTexts", order = 2)]
    public class LabelText : ScriptableObject {
        [SerializeField] private ELabel label;

        public string Text => GetLabel(label);
    }
}
