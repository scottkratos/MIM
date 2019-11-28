using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmazenRow : MonoBehaviour
{
    public string Nome;
    public float Size;
    public App.DataType Type;
    public Sprite[] ibagens;
    public bool IsApp;
    public App app;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    [SerializeField]
    private TMPro.TextMeshProUGUI texto;
    public Image ibagem;

    private void Start()
    {
        text.text = Nome;
        if (Size / 1000f >= 1)
        {
            if ((Size / 1000f) / 1000f >= 1)
            {
                if (((Size / 1000f) / 1000f) / 931f >= 1)
                {
                    texto.text = (int)(((Size / 1000f) / 1000f) / 931f) + " TB";
                }
                else
                {
                    texto.text = (int)((Size / 1000f) / 1000f) + " GB";
                }
            }
            else
            {
                texto.text = (int)(Size / 1000f) + " MB";
            }
        }
        else
        {
            texto.text = (int)Size + " KB";
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

    public void Delete()
    {
        switch (Type)
        {
            case App.DataType.FilmesTV:
                PageControl.Instance.ArmazenamentoFilmesTV -= Size;
                break;
            case App.DataType.FotoseVideo:
                PageControl.Instance.ArmazenamentoFotoseVideo -= Size;
                break;
            case App.DataType.Jogos:
                PageControl.Instance.ArmazenamentoJogos -= Size;
                break;
            case App.DataType.MusicaeAudio:
                PageControl.Instance.ArmazenamentoMusicaeAudio -= Size;
                break;
            case App.DataType.Outros:
                PageControl.Instance.ArmazenamentoOutros -= Size;
                break;
        }
        PageControl.Instance.ArmazenamentoTotalOcupado -= Size;
        if (IsApp)
        {
            PageControl.Instance.UninstallApp(app.Type);
        }
        else
        {
            for (int i = 0; i < PageControl.Instance.Arquivos.Count; i++)
            {
                if (PageControl.Instance.Arquivos[i].Nome == Nome)
                {
                    PageControl.Instance.Arquivos.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < PageControl.Instance.ArquivosTransmitidos.Count; i++)
            {
                if (PageControl.Instance.ArquivosTransmitidos[i].Nome == Nome)
                {
                    PageControl.Instance.ArquivosTransmitidos.RemoveAt(i);
                    break;
                }
            }
        }
        AudioManager.Instance.PlaySFX(0);
        foreach (ArmazenamentoDisplayManager adm in ArmazenamentoDisplayManager.Instances)
        {
            adm.Spawn();
        }
    }
}
