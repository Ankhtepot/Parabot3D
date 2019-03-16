using Assets.Scripts.Texts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Texts.Labels;

[CreateAssetMenu(fileName = "Provided Text", menuName = "ScriptableObjects/labelTexts", order = 2)]
public class LabelTextProvider : ScriptableObject {
#pragma warning disable 649
    [SerializeField] Texts text;
#pragma warning disable 649

    public string GetText() {
        return Labels.getText(text);
    }
}
