using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pelicula : TouchSystem, IDragHandler, IEndDragHandler
{
    [Range(1, 2, order = 1)]
    public int Index;
    public int width;
    public int height;
    public List<Line> lines = new List<Line>();
    private static bool IsMoving;
    public Vector3 initialPos;
    private static Vector3 RefPos;
    private static Vector3 initialClick = new Vector3(5000, 5000, 5000);
    private Pelicula[] Instances;
    private Vector3 Distance;
    private bool IsAdapting = false;
    private RectTransform RT;

    private void Awake()
    {
        RT = GetComponent<RectTransform>();
        RefPos = new Vector3(0, RT.localPosition.y, RT.localPosition.z);
        initialPos = RT.localPosition;
        Instances = FindObjectsOfType<Pelicula>();
        for (int i = 0; i < transform.childCount; i++)
        {
            lines.Add(transform.GetChild(i).GetComponent<Line>());
            lines[i].ID = i;
        }
    }
    protected override void Update()
    {
        base.Update();
        if (IsMoving)
        {
            Distance = RT.localPosition;
            if (initialClick.x == 5000)
            {
                initialClick = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
            RT.localPosition = new Vector3(initialPos.x + (Camera.main.ScreenToViewportPoint(Input.mousePosition).x - initialClick.x) * width, initialPos.y, initialPos.z);
        }
        if (IsAdapting)
        {
            float VEL = 100;
            if (Mathf.Abs(RT.localPosition.x - (RefPos.x + width * (Index - PageControl.Instance.CurrentPage))) <= VEL)
            {
                IsAdapting = false;
                RT.localPosition = new Vector3(RefPos.x + width * (Index - PageControl.Instance.CurrentPage), RefPos.y, RefPos.z);
                initialPos = RT.localPosition;
            }
            else
            {
                if (RT.localPosition.x > RefPos.x + width * (Index - PageControl.Instance.CurrentPage))
                {
                    RT.localPosition = new Vector3(RT.localPosition.x - VEL, RefPos.y, RefPos.z);
                }
                else if (RT.localPosition.x < RefPos.x + width * (Index - PageControl.Instance.CurrentPage))
                {
                    RT.localPosition = new Vector3(RT.localPosition.x + VEL, RefPos.y, RefPos.z);
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        IsMoving = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        IsMoving = false;
        if (RT.localPosition.x - Distance.x < 10 && RT.localPosition.x - Distance.x > -10)
        {
            if (RT.localPosition.x > 0)
            {
                if (PageControl.Instance.CurrentPage - 1 > 0)
                {
                    PageControl.Instance.CurrentPage--;
                }
            }
            else if (RT.localPosition.x <= 0)
            {
                if (PageControl.Instance.CurrentPage < PageControl.Instance.Pages)
                {
                    PageControl.Instance.CurrentPage++;
                }
            }
        }
        else
        {
            if (RT.localPosition.x - Distance.x > 10)
            {
                if (PageControl.Instance.CurrentPage - 1 > 0)
                {
                    PageControl.Instance.CurrentPage--;
                }
            }
            else
            {
                if (PageControl.Instance.CurrentPage < PageControl.Instance.Pages)
                {
                    PageControl.Instance.CurrentPage++;
                }
            }
        }
        foreach (Pelicula _pelicula in Instances)
        {
            _pelicula.Drop();
        }
        Distance = new Vector3(0, 0, 0);
    }
    public void Drop()
    {
        IsAdapting = true;
        initialClick = new Vector3(5000, 5000, 5000);
    }
}
