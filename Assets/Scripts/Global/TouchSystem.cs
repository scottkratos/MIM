using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchSystem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    protected float TIME = 1.5f;
    protected Vector3 mousePos;
    protected float mouseTime;
    protected bool mouseTouch;

    public void OnPointerDown(PointerEventData eventData)
    {
        mouseTime = 0;
        mousePos = Input.mousePosition;
        mouseTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mouseTouch = false;
        if (mouseTime > TIME)
        {
            DetectTouchStayExit();
        }
        else
        {
            DetectClick();
        }
    }

    protected virtual void Update()
    {
        if (mouseTouch)
        {
            if (mousePos == Input.mousePosition)
            {
                if (mouseTime > TIME)
                {
                    DetectTouchStay();
                }
            }
            else
            {
                mousePos = Input.mousePosition;
                mouseTime = 0;
            }
            mouseTime += Time.deltaTime;
        }
    }
    protected virtual void DetectClick()
    {

    }
    protected virtual void DetectTouchStay()
    {

    }
    protected virtual void DetectTouchStayExit()
    {
    }
}
