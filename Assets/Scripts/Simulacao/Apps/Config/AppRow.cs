using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppRow : MonoBehaviour
{
    public bool IsWifi;
    public App _app;
    [SerializeField]
    private TMPro.TextMeshProUGUI Titulo;
    [SerializeField]
    private TMPro.TextMeshProUGUI Desc;
    [SerializeField]
    private Image Icon;

    private void Update()
    {
        Titulo.text = _app.Name;
        Icon.sprite = _app.Image;
        if (IsWifi)
        {
            if (_app.RedeUsada / 1000f >= 1)
            {
                if ((_app.RedeUsada / 1000f) / 1000f >= 1)
                {
                    if (((_app.RedeUsada / 1000f) / 1000f) / 931f >= 1)
                    {
                        Desc.text = (int)(((_app.RedeUsada / 1000f) / 1000f) / 931f) + " TB de dados usados";
                    }
                    else
                    {
                        Desc.text = (int)((_app.RedeUsada / 1000f) / 1000f) + " GB de dados usados";
                    }
                }
                else
                {
                    Desc.text = (int)(_app.RedeUsada / 1000f) + " MB de dados usados";
                }
            }
            else
            {
                Desc.text = (int)_app.RedeUsada + " KB de dados usados";
            }
        }
        else
        {
            if (_app.DadosMoveisUsados / 1000f >= 1)
            {
                if ((_app.DadosMoveisUsados / 1000f) / 1000f >= 1)
                {
                    if (((_app.DadosMoveisUsados / 1000f) / 1000f) / 931f >= 1)
                    {
                        Desc.text = (int)(((_app.DadosMoveisUsados / 1000f) / 1000f) / 931f) + " TB de dados usados";
                    }
                    else
                    {
                        Desc.text = (int)((_app.DadosMoveisUsados / 1000f) / 1000f) + " GB de dados usados";
                    }
                }
                else
                {
                    Desc.text = (int)(_app.DadosMoveisUsados / 1000f) +  " MB de dados usados";
                }
            }
            else
            {
                Desc.text = (int)_app.DadosMoveisUsados + " KB de dados usados";
            }
        }
    }
}
