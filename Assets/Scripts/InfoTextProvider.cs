using Assets.Scripts.Texts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Texts.generalInfos;

[CreateAssetMenu(fileName = "Provided Text", menuName = "ScriptableObjects/infoTexts", order = 1)]
public class InfoTextProvider : ScriptableObject {
#pragma warning disable 649
    [SerializeField] Texts text;
#pragma warning disable 649

    public string getText() {
        return generalInfos.getText(text);
    }
}
