using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchiveRow : MonoBehaviour
{
    public string Nome;
    public float Size;
    public App.DataType Type;
    public Sprite[] ibagens;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    [SerializeField]
    private TMPro.TextMeshProUGUI texto;
    [SerializeField]
    private Image ibagem;

    private void Start()
    {
        text.text = Nome;
        if (Size / 1000f >= 1)
        {
            if ((Size / 1000f) / 1000f >= 1)
            {
                if (((Size / 1000f) / 1000f) / 931f >= 1)
                {
                    texto.text = (int)(((Size / 1000f) / 1000f) / 931f) + " TB de armazenamento";
                }
                else
                {
                    texto.text = (int)((Size / 1000f) / 1000f) + " GB de armazenamento";
                }
            }
            else
            {
                texto.text = (int)(Size / 1000f) + " MB de armazenamento";
            }
        }
        else
        {
            texto.text = (int)Size + " KB de armazenamento";
        }
        if (ibagem.sprite == null)
        {
            switch (Type)
            {
                case App.DataType.FilmesTV:
                    ibagem.sprite = ibagens[0];
                    ibagem.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 80);
                    break;
                case App.DataType.FotoseVideo:
                    ibagem.sprite = ibagens[1];
                    ibagem.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
                    break;
                case App.DataType.Jogos:
                    ibagem.sprite = ibagens[4];
                    ibagem.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 80);
                    break;
                case App.DataType.MusicaeAudio:
                    ibagem.sprite = ibagens[2];
                    ibagem.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 100);
                    break;
                case App.DataType.Outros:
                    ibagem.sprite = ibagens[3];
                    ibagem.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 80);
                    break;
            }
        }
    }
}
