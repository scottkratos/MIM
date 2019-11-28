using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GavetaPelicula : TouchSystem, IDragHandler, IEndDragHandler
{
    [Range(1, 2, order = 1)]
    public int Index;
    public int width;
    public int height;
    public bool NeedTamanho;
    private static bool IsMoving;
    public Vector3 initialPos;
    private static Vector3 RefPos;
    private static Vector3 initialClick = new Vector3(5000, 5000, 5000);
    private GavetaPelicula[] Instances;
    private Vector3 Distance;
    private bool IsAdapting = false;
    private RectTransform RT;
    private float Tamanho = 0;

    private void Start()
    {
        RT = GetComponent<RectTransform>();
        initialPos = RT.localPosition;
        RefPos = new Vector3(RT.localPosition.x, 0, RT.localPosition.z);
        initialPos = RT.localPosition;
        Instances = FindObjectsOfType<GavetaPelicula>();
        if (NeedTamanho) Tamanho = RT.localPosition.y;
    }
    protected override void Update()
    {
        base.Update();
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
            if (Mathf.Abs(RT.localPosition.y - (RefPos.y + Tamanho - height * (Index - PageControl.Instance.IsGaveta))) <= VEL)
            {
                IsAdapting = false;
                RT.localPosition = new Vector3(RefPos.x, RefPos.y + Tamanho - height * (Index - PageControl.Instance.IsGaveta), RefPos.z);
                initialPos = RT.localPosition;
            }
            else
            {
                if (RT.localPosition.y > RefPos.y + Tamanho - height * (Index - PageControl.Instance.IsGaveta))
                {
                    RT.localPosition = new Vector3(RefPos.x, RT.localPosition.y - VEL, RefPos.z);
                }
                else if (RT.localPosition.y < RefPos.y + Tamanho - height * (Index - PageControl.Instance.IsGaveta))
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
                    if (RT.localPosition.y < 0)
                    {
                        PageControl.Instance.IsGaveta = 1;
                    }
                    else if (RT.localPosition.y >= 0)
                    {
                        PageControl.Instance.IsGaveta = 2;
                    }
                }
                else
                {
                    if (RT.localPosition.y - Distance.y < 10)
                    {
                        PageControl.Instance.IsGaveta = 1;
                    }
                    else
                    {
                        PageControl.Instance.IsGaveta = 2;
                    }
                }
                break;
            case 2:
                if (RT.localPosition.y - Distance.y < 10 && RT.localPosition.y - Distance.y > -10)
                {
                    if (RT.localPosition.y < -1040)
                    {
                        PageControl.Instance.IsGaveta = 1;
                    }
                    else if (RT.localPosition.y >= -1040)
                    {
                        PageControl.Instance.IsGaveta = 2;
                    }
                }
                else
                {
                    if (RT.localPosition.y - Distance.y < 10)
                    {
                        PageControl.Instance.IsGaveta = 1;
                    }
                    else
                    {
                        PageControl.Instance.IsGaveta = 2;
                    }
                }
                break;
        }
        foreach (GavetaPelicula _pelicula in Instances)
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
