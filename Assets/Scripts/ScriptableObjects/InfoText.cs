using UnityEngine;
using static Texts.generalInfos;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Provided Text", menuName = "ScriptableObjects/infoTexts", order = 1)]
    public class InfoText : ScriptableObject 
    {
        [SerializeField] private ETexts text;

        public string Text => getText(text);
    }
}
