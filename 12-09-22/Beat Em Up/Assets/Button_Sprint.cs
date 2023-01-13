using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//public class Button_Sprint : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
//{
//    public bool isPressed;
//    public bool SinglePresed;
//    public bool color;

//    public void OnUpdateSelected(BaseEventData data)
//    {
//        if (isPressed)
//        {
//            isPressed = true;
//        }
//    }

//    public void OnPointerDown(PointerEventData data)
//    {
//        if (SinglePresed)
//        {
//            if (isPressed == false)// same as !isPressed
//            {
//                if(color)
//                    gameObject.GetComponent<Image>().color = Color.gray;
//                isPressed = true;
//            }
//            else
//            {
//                if (color)
//                    gameObject.GetComponent<Image>().color = Color.white;
//                isPressed = false;
//            }
//        }
//        else
//        {
//            isPressed = true;
//        }
//    }
//    public void OnPointerUp(PointerEventData data)
//    {

//        if (!SinglePresed)
//        {
//            isPressed = false;
//            gameObject.GetComponent<Image>().color = Color.white;
//        }
//    }

//}


public class Button_Sprint : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed;
    public bool SinglePresed;

    public void OnUpdateSelected(BaseEventData data)
    {
        if (isPressed)
        {
            isPressed = true;
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        if (SinglePresed)
        {
            if (isPressed == false)// same as !isPressed
            {
                //gameObject.GetComponent<Image>().color = Color.gray;
                isPressed = true;
            }
            else
            {
                //gameObject.GetComponent<Image>().color = Color.white;
                isPressed = false;
            }
        }
        else
        {
            isPressed = true;
        }
    }
    public void OnPointerUp(PointerEventData data)
    {

        if (!SinglePresed)
        {
            isPressed = false;
            gameObject.GetComponent<Image>().color = Color.white;
        }
    }

}
