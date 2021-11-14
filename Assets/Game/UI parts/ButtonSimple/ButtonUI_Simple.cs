using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Constants.enums;

public class ButtonUI_Simple : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
#pragma warning disable 649
    [SerializeField] LabelTextProvider Label;
    [SerializeField] Image frameImage;
    [SerializeField] private Image[] colorChangableImages;
    [SerializeField] float colorChangeSpeed = 0.1f;
    [SerializeField] Color normalColor;
    [SerializeField] Color hoverColor;
    [SerializeField] Color clickColor;
    [SerializeField] Color disabledColor = Color.grey;
    [SerializeField] Color activeColor;
    [SerializeField] Color nonActiveColor;
    [SerializeField] UnityEvent OnMouseDown;
    [SerializeField] UnityEvent OnMouseUp;
    [SerializeField] TextMeshProUGUI text;
#pragma warning restore 649

    //caches
    private bool RuntimeEnabled = true;
    [SerializeField] Color targetColor = Color.white;
    [SerializeField] Color changableImagesTargetColor = Color.white;

    private void Start() {
        if(text) text.text = Label.GetText();
        if (!RuntimeEnabled) Disable();
        if (RuntimeEnabled) Enable();
    }

    private void Update() {
        handleColors();
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (RuntimeEnabled) {
            handleMouseDown();
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (RuntimeEnabled) {
            handleMouseUp();
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (RuntimeEnabled) {
            //print("OnPointerEnter");
            handleMouseEnter();
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (RuntimeEnabled) {
            handleMouseExit();
        }
    }

    public void Enable() {
        RuntimeEnabled = true;
        targetColor = normalColor;
    }

    public void Disable() {
        RuntimeEnabled = false;
        targetColor = disabledColor;
    }

    public void SetActiveColorForChangableImages() {
        changableImagesTargetColor = activeColor;
    }

    public void setNonActiveColorsForChangableImages() {
        changableImagesTargetColor = nonActiveColor;
    }

    private void handleMouseUp() {
        targetColor = hoverColor;
        OnMouseUp.Invoke();
    }

    private void handleColors() {
        if (colorChangableImages.Length > 0 && colorChangableImages[0].color != changableImagesTargetColor) {
            foreach (Image image in colorChangableImages) {
                image.color = Color.Lerp(image.color, changableImagesTargetColor, colorChangeSpeed);
            } 
        }
        if (text && text.color != targetColor) {
            text.color = Color.Lerp(text.color, targetColor, colorChangeSpeed);
        }
        if (frameImage && frameImage.color != targetColor) {
            if (frameImage) frameImage.color = Color.Lerp(frameImage.color, targetColor, colorChangeSpeed); 
        }
    }

    private void handleMouseDown() {
        targetColor = clickColor;
        OnMouseDown.Invoke();
    }

    private void handleMouseEnter() {
        //print("handleMouseEnter");
        targetColor = hoverColor;
    }

    private void handleMouseExit() {
        targetColor = normalColor;
    }
}
