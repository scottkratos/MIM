using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FakeApp : TouchSystem
{
    [Header("Configurações:")]
    public Sprite Image;
    public string Name;
    public App.AppType Type;
    [Space]
    [Header("Constantes:")]
    [SerializeField]
    private Image ImComp;
    [SerializeField]
    private TMPro.TextMeshProUGUI TeComp;
    private bool IsEdit = false;

    private void Start()
    {
        ImComp = GetComponentInChildren<Image>();
        TeComp = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        ImComp.sprite = Image;
        TeComp.text = Name;
    }

    protected override void DetectClick()
    {
        switch (Type)
        {
            case App.AppType.Config:
                PageControl.Instance.OpenApp(1);
                break;
            case App.AppType.GooglePlay:
                PageControl.Instance.OpenApp(2);
                break;
            case App.AppType.Discador:
                PageControl.Instance.OpenApp(3);
                break;
            case App.AppType.Contatos:
                PageControl.Instance.OpenApp(4);
                break;
            case App.AppType.Mensagens:
                PageControl.Instance.OpenApp(5);
                break;
        }
    }
    protected override void DetectTouchStay()
    {
    }
}
