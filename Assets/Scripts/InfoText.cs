using System;
using UnityEngine;
using static Texts.generalInfos;

[CreateAssetMenu(fileName = "Provided Text", menuName = "ScriptableObjects/infoTexts", order = 1)]
public class InfoText : ScriptableObject 
{
#pragma warning disable 649
    [SerializeField] private ETexts text;
#pragma warning disable 649

    public string Text => getText(text);
}
