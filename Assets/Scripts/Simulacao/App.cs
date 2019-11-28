using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class App : TouchSystem, IDragHandler, IEndDragHandler
{
    [Header("Configurações:")]
    public Sprite Image;
    public string Name;
    public AppType Type;
    public DataType dataType;
    public int Size;
    public float DadosMoveisUsados;
    public float RedeUsada;
    public float DadosPerSec;
    [Space]
    [Header("Constantes:")]
    [SerializeField]
    private Image ImComp;
    [SerializeField]
    private TMPro.TextMeshProUGUI TeComp;
    private Pelicula[] peliculas;
    private bool Drag;
    private bool IsEdit = false;

    private void Start()
    {
        ImComp = GetComponentInChildren<Image>();
        TeComp = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        ImComp.sprite = Image;
        TeComp.text = Name;
        peliculas = FindObjectsOfType<Pelicula>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsEdit)
        {
            Drag = true;
            foreach (Pelicula _pelicula in peliculas)
            {
                if (_pelicula.Index == PageControl.Instance.CurrentPage)
                {
                    _pelicula.OnDrag(eventData);
                    break;
                }
            }
        }
        else
        {

        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsEdit)
        {
            Drag = false;
            foreach (Pelicula _pelicula in peliculas)
            {
                if (_pelicula.Index == PageControl.Instance.CurrentPage)
                {
                    _pelicula.OnEndDrag(eventData);
                    break;
                }
            }
        }
        else
        {

        }
    }
    protected override void DetectClick()
    {
        AudioManager.Instance.PlaySFX(0);
        if (!Drag)
        {
            switch (Type)
            {
                case AppType.Config:
                    PageControl.Instance.OpenApp(1);
                    ConfigMaster.PageIndex = 0;
                    break;
                case AppType.GoogleChrome:
                    PageControl.Instance.OpenApp(2);
                    ChromeMaster.Instance.localInst = this;
                    ChromeMaster.Instance.EnterSite();
                    break;
                case AppType.Wpp:
                    PageControl.Instance.OpenApp(3);
                    WhatsConfg.PageIndex = 0;
                    break;
                case AppType.GooglePlay:
                    PageControl.Instance.OpenApp(4);
                    GplayConfig.Instance.Pageindex = 1;
                    break;
            }
        }
    }
    protected override void DetectTouchStay()
    {
        if (!Drag)
        {
            IsEdit = true;
        }
    }
    public enum AppType
    {
        Nothing,
        Config,
        GooglePlay,
        Discador,
        Contatos,
        Mensagens,
        Wpp,
        GoogleChrome,
        Gaveta,
        Pokemon,
        myboy,
        oldbyboy,
        tinder,
        empatia,
        pou
    }
    public enum DataType
    {
        FotoseVideo,
        MusicaeAudio,
        Jogos,
        FilmesTV, 
        Outros
    }
}
