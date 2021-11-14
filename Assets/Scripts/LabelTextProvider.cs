using UnityEngine;
using static Texts.Labels;

[CreateAssetMenu(fileName = "Provided Text", menuName = "ScriptableObjects/labelTexts", order = 2)]
public class LabelTextProvider : ScriptableObject {
    [SerializeField] private ELabel label;

    public string GetText() {
        return GetLabel(label);
    }
}
