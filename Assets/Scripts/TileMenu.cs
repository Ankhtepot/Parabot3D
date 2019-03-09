using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMenu : MonoBehaviour
{
    [Header("Buttons to use")]
    [SerializeField] List<TileMenuButton> buttons = new List<TileMenuButton>();

    public void ShowButtons() {
        foreach(TileMenuButton button in buttons) {
            //print("TileMenu level: buttons showing up");
            button.ShowUp();
        }
    }

    public void HideButtons() {
        foreach (TileMenuButton button in buttons) {
            //print("TileMenu level: hiding buttons");
            button.Hide();
        }
    }
}
