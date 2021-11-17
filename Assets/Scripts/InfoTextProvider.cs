using System;
using Texts;
using UnityEngine;
using static Texts.generalInfos;

[CreateAssetMenu(fileName = "Provided Text", menuName = "ScriptableObjects/infoTexts", order = 1)]
public class InfoTextProvider : ScriptableObject 
{
#pragma warning disable 649
    [SerializeField] private ETexts text;
#pragma warning disable 649

    public string Text => generalInfos.getText(text);
}
