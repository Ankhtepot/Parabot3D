using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.CrossPlatformInput;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image joystickImage;
    [SerializeField] private Vector3 inputVector;

    public Vector2 JoystickPosition
    {
        get { return joystickImage.rectTransform.anchoredPosition; }
        set { joystickImage.rectTransform.anchoredPosition = value; }
    }

    private void Start()
    {
        backgroundImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        Vector2 sizeDelta = backgroundImage.rectTransform.sizeDelta;
        
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            backgroundImage.rectTransform
            , eventData.position
            , eventData.pressEventCamera
            , out position))
        {
            //print("Position before transform: " + position);
            position.x = (position.x / sizeDelta.x);
            position.y = (position.y / sizeDelta.y);
            
            inputVector = new Vector3(position.x*2,0,position.y*2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            JoystickPosition =
                new Vector2(inputVector.x * (sizeDelta.x / 3)
                    , inputVector.z * (sizeDelta.y / 3));

            //print($"Position after transform: {inputVector} : rTrans.sizeDelta.x: {sizeDelta.x} |:| rTrans.sizeDelta.y: {sizeDelta.y}");
        };
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);    
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        joystickImage.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float GetHorizontal()
    {
        if (inputVector.x != 0) return inputVector.x;
        else return CrossPlatformInputManager.GetAxis(input.HORIZONTAL);
    }
    
    public float GetVertical()
    {
        if (inputVector.z != 0) return inputVector.z;
        else return CrossPlatformInputManager.GetAxis(input.VERTICAL);
    }

}
