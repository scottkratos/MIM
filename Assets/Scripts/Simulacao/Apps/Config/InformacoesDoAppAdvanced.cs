using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformacoesDoAppAdvanced : MonoBehaviour
{
    public App app;
    public Image icon;
    public TMPro.TextMeshProUGUI Armazen;
    public TMPro.TextMeshProUGUI Dados;
    public TMPro.TextMeshProUGUI Rede;
    public TMPro.TextMeshProUGUI Nome;
    private ConfigMaster cfg;

    private void Start()
    {
        cfg = FindObjectOfType<ConfigMaster>();
    }

    public void Create()
    {
        Nome.text = app.Name;
        icon.sprite = app.Image;
        if (app.RedeUsada / 1000f >= 1)
        {
            if ((app.RedeUsada / 1000f) / 1000f >= 1)
            {
                if (((app.RedeUsada / 1000f) / 1000f) / 931f >= 1)
                {
                    Rede.text = (int)(((app.RedeUsada / 1000f) / 1000f) / 931f) + " TB de rede usada";
                }
                else
                {
                    Rede.text = (int)((app.RedeUsada / 1000f) / 1000f) + " GB de rede usada";
                }
            }
            else
            {
                Rede.text = (int)(app.RedeUsada / 1000f) + " MB de rede usada";
            }
        }
        else
        {
            Rede.text = (int)app.RedeUsada + " KB de rede usada";
        }
        if (app.DadosMoveisUsados / 1000f >= 1)
        {
            if ((app.DadosMoveisUsados / 1000f) / 1000f >= 1)
            {
                if (((app.DadosMoveisUsados / 1000f) / 1000f) / 931f >= 1)
                {
                    Dados.text = (int)(((app.DadosMoveisUsados / 1000f) / 1000f) / 931f) + " TB de dados usados";
                }
                else
                {
                    Dados.text = (int)((app.DadosMoveisUsados / 1000f) / 1000f) + " GB de dados usados";
                }
            }
            else
            {
                Dados.text = (int)(app.DadosMoveisUsados / 1000f) + " MB de dados usados";
            }
        }
        else
        {
            Dados.text = (int)app.DadosMoveisUsados + " KB de dados usados";
        }
        if (app.Size / 1000f >= 1)
        {
            if ((app.Size / 1000f) / 1000f >= 1)
            {
                if (((app.Size / 1000f) / 1000f) / 931f >= 1)
                {
                    Armazen.text = (int)(((app.Size / 1000f) / 1000f) / 931f) + " TB de espaço ocupado";
                }
                else
                {
                    Armazen.text = (int)((app.Size / 1000f) / 1000f) + " GB de espaço ocupado";
                }
            }
            else
            {
                Armazen.text = (int)(app.Size / 1000f) + " MB de espaço ocupado";
            }
        }
        else
        {
            Armazen.text = (int)app.Size + " KB de espaço ocupado";
        }
    }
    public void Desinstall()
    {
        switch (app.Type)
        {
            default:
                PageControl.Instance.UninstallApp(app.Type);
                break;
            case App.AppType.Config:
                break;
        }
        cfg.EnterSubmenu(23);
    }
}
