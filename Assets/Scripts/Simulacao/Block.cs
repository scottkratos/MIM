using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Block : TouchSystem, IDragHandler, IEndDragHandler
{
    public static Block Instance;
    public TMPro.TextMeshProUGUI Tempo;
    public TMPro.TextMeshProUGUI Data;
    public int Index = 1;
    public int width;
    public int height;
    private static bool IsMoving;
    public Vector3 initialPos;
    private static Vector3 RefPos;
    private static Vector3 initialClick = new Vector3(5000, 5000, 5000);
    private Vector3 Distance;
    private bool IsAdapting = false;
    private RectTransform RT;
    public int page = 1;
    [SerializeField]
    private GameObject image;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        RT = GetComponent<RectTransform>();
        initialPos = RT.localPosition;
        RefPos = new Vector3(RT.localPosition.x, 0, RT.localPosition.z);
        initialPos = RT.localPosition;
    }
    private void FixedUpdate()
    {
        image.GetComponent<Image>().sprite = PageControl.Instance.backgrounds[PageControl.Instance.BackgroundIndex];
        if (IsMoving)
        {
            Distance = RT.localPosition;
            if (initialClick.y == 5000)
            {
                initialClick = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
            RT.localPosition = new Vector3(initialPos.x, initialPos.y + (Camera.main.ScreenToViewportPoint(Input.mousePosition).y - initialClick.y) * height, initialPos.z);
        }
        if (IsAdapting)
        {
            float VEL = 100;
            if (Mathf.Abs(RT.localPosition.y - (RefPos.y - height * (Index - page))) <= VEL)
            {
                IsAdapting = false;
                RT.localPosition = new Vector3(RefPos.x, RefPos.y - height * (Index - page), RefPos.z);
                initialPos = RT.localPosition;
                if (page == 2) PageControl.Instance.IsBlocked = false;
            }
            else
            {
                if (RT.localPosition.y > RefPos.y - height * (Index - page))
                {
                    RT.localPosition = new Vector3(RefPos.x, RT.localPosition.y - VEL, RefPos.z);
                }
                else if (RT.localPosition.y < RefPos.y - height * (Index - page))
                {
                    RT.localPosition = new Vector3(RefPos.x, RT.localPosition.y + VEL, RefPos.z);
                }
            }
        }
        if (Index == 2)
        {
            if (RT.localPosition.y > 0) RT.localPosition = new Vector3(RT.localPosition.x, 0, RT.localPosition.z);
        }
    }
    protected override void Update()
    {
        base.Update();
        if (DateTime.Now.Minute.ToString().Length > 1)
        {
            Tempo.text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }
        else
        {
            Tempo.text = DateTime.Now.Hour + ":0" + DateTime.Now.Minute;
        }
        string ptbr = "as";
        string brpt = "sa";
        switch (DateTime.Now.DayOfWeek)
        {
            case DayOfWeek.Monday:
                ptbr = "Seg";
                break;
            case DayOfWeek.Tuesday:
                ptbr = "Ter";
                break;
            case DayOfWeek.Wednesday:
                ptbr = "Qua";
                break;
            case DayOfWeek.Thursday:
                ptbr = "Qui";
                break;
            case DayOfWeek.Friday:
                ptbr = "Sex";
                break;
            case DayOfWeek.Saturday:
                ptbr = "Sab";
                break;
            case DayOfWeek.Sunday:
                ptbr = "Dom";
                break;
        }
        switch (DateTime.Now.Month)
        {
            case 1:
                brpt = "Jan";
                break;
            case 2:
                brpt = "Fev";
                break;
            case 3:
                brpt = "Mar";
                break;
            case 4:
                brpt = "Abr";
                break;
            case 5:
                brpt = "Mai";
                break;
            case 6:
                brpt = "Jun";
                break;
            case 7:
                brpt = "Jul";
                break;
            case 8:
                brpt = "Ago";
                break;
            case 9:
                brpt = "Set";
                break;
            case 10:
                brpt = "Out";
                break;
            case 11:
                brpt = "Nov";
                break;
            case 12:
                brpt = "Dez";
                break;
        }
        Data.text = ptbr + ", " + DateTime.Now.Day + " de " + brpt;
    }
    public void OnDrag(PointerEventData eventData)
    {
        IsMoving = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        IsMoving = false;
        switch (Index)
        {
            case 1:
                if (RT.localPosition.y - Distance.y < 10 && RT.localPosition.y - Distance.y > -10)
                {
                    if (RT.localPosition.y < 960)
                    {
                        page = 1;
                    }
                    else if (RT.localPosition.y >= 960)
                    {
                        page = 2;
                    }
                }
                else
                {
                    if (RT.localPosition.y - Distance.y < 10)
                    {
                        page = 1;
                    }
                    else
                    {
                        page = 2;
                    }
                }
                break;
        }
        Drop();
        Distance = new Vector3(0, 0, 0);
    }
    public void Drop()
    {
        IsAdapting = true;
        initialClick = new Vector3(5000, 5000, 5000);
    }
}

