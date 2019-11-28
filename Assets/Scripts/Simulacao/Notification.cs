
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Notification : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
    public string Tit;
    public string Desc;
    public Sprite Png;
    public GameObject Prefab;
    public GameObject NotifyOptions;
    [SerializeField]
    private TMPro.TextMeshProUGUI Titulo;
    [SerializeField]
    private TMPro.TextMeshProUGUI Descricao;
    [SerializeField]
    private TMPro.TextMeshProUGUI Tempo;
    [SerializeField]
    private Image Icon;
    [SerializeField]
    private GameObject ClonePrefab;
    private RectTransform RT;
    private Vector3 initialClick;
    private float TIME = 1.5f;
    private Vector3 mousePos;
    private float mouseTime;
    private bool mouseTouch;
    private GameObject parent;
    private int Index;
    private bool IsDragging;
    private bool Lock = false;
    private List<Image> Allimages = new List<Image>();
    private List<TMPro.TextMeshProUGUI> AllText = new List<TMPro.TextMeshProUGUI>();
    private float[] TextAlphas;
    private GameObject Clone;
    private bool Softlock = false;
    OpcoesRapidasPelicula superparent;

    private void Start()
    {
        superparent = GetComponentInParent<OpcoesRapidasPelicula>();
        RT = GetComponent<RectTransform>();
        parent = transform.parent.gameObject;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).gameObject == gameObject)
            {
                Index = i;
                break;
            }
        }
        Allimages.Add(GetComponent<Image>());
        foreach (Image _image in GetComponentsInChildren<Image>())
        {
            Allimages.Add(_image);
        }
        foreach (TMPro.TextMeshProUGUI _text in GetComponentsInChildren<TMPro.TextMeshProUGUI>())
        {
            AllText.Add(_text);
        }
        TextAlphas = new float[AllText.Count];
        for (int i = 0; i < AllText.Count; i++)
        {
            TextAlphas[i] = AllText[i].color.a;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        mouseTime = 0;
        mousePos = Input.mousePosition;
        mouseTouch = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Lock = false;
        IsDragging = false;
        if (Softlock)
        {
            superparent.OnEndDrag(eventData);
        }
        if (Mathf.Abs(RT.localPosition.x) > 150)
        {
            Destroy(Clone);
            Destroy(gameObject);
        }
        else
        {
            Destroy(Clone);
            transform.SetParent(parent.transform);
            transform.SetSiblingIndex(Index);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Camera.main.ScreenToViewportPoint(Input.mousePosition).x < 0.6f  && Camera.main.ScreenToViewportPoint(Input.mousePosition).x > 0.5f)
        {
            superparent.OnDrag(eventData);
            RT.localPosition = new Vector3(0, RT.localPosition.y, RT.localPosition.z);
            Softlock = true;
            return;
        }
        if (!Lock)
        {
            initialClick = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Clone = Instantiate(ClonePrefab, parent.transform);
            Clone.transform.SetSiblingIndex(Index);
            Lock = true;
        }
        IsDragging = true;
        if (Camera.main.ScreenToViewportPoint(Input.mousePosition).x >= 0.6f || Camera.main.ScreenToViewportPoint(Input.mousePosition).x <= 0.5f)
        {
            DetectClose(eventData);
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        if (IsDragging || Softlock) return;
        mouseTouch = false;
        if (mouseTime < TIME)
        {
            DetectClick();
        }
    }

    private void Update()
    {
        int number = Mathf.Clamp((int)Mathf.Abs(RT.localPosition.x), 0, 255);
        foreach (Image _image in Allimages)
        {
            _image.color = new Color32((byte)(255 * _image.color.r), (byte)(255 * _image.color.g), (byte)(255 * _image.color.b), (byte)(255 - number));
        }
        int miniindex = 0;
        foreach (TMPro.TextMeshProUGUI _text in AllText)
        {
            _text.color = new Color32((byte)(255 * _text.color.r), (byte)(255 * _text.color.g), (byte)(255 * _text.color.b), (byte)((255 * TextAlphas[miniindex]) - number));
            miniindex++;
        }
        if (mouseTouch)
        {
            if (mousePos == Input.mousePosition)
            {
                if (mouseTime > TIME)
                {
                    DetectTouchStay();
                }
            }
            mouseTime += Time.deltaTime;
        }
    }
    public void UpdateInfo()
    {
        Titulo.text = Tit;
        Descricao.text = Desc;
        Icon.sprite = Png;
    }

    private void DetectClick()
    {
        Prefab.SetActive(true);
        Destroy(gameObject);
    }
    private void DetectTouchStay()
    {
        NotifyOptions.SetActive(true);
    }

    public void DetectClose(PointerEventData eventData)
    {
        superparent.OnEndDrag(eventData);
        transform.SetParent(parent.transform.parent.transform);
        mouseTime = 0;
        RT.localPosition = new Vector3((Camera.main.ScreenToViewportPoint(Input.mousePosition).x - initialClick.x) * 1080, RT.localPosition.y, RT.localPosition.z);
    }
}
