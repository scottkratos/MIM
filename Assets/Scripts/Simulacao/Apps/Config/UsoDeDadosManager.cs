using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsoDeDadosManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI Dados;
    [SerializeField]
    private TMPro.TextMeshProUGUI WiFi;

    private void Update()
    {
        if (PageControl.Instance.DadosUsados / 1000f >= 1)
        {
            if ((PageControl.Instance.DadosUsados / 1000f) / 1000f >= 1)
            {
                if (((PageControl.Instance.DadosUsados / 1000f) / 1000f) / 931f >= 1)
                {
                    Dados.text = "<size=100><b>" + (int)(((PageControl.Instance.DadosUsados / 1000f) / 1000f) / 931f) + " TB</b></size> de dados usados";
                }
                else
                {
                    Dados.text = "<size=100><b>" + (int)((PageControl.Instance.DadosUsados / 1000f) / 1000f) + " GB</b></size> de dados usados";
                }
            }
            else
            {
                Dados.text = "<size=100><b>" + (int)(PageControl.Instance.DadosUsados / 1000f) + " MB</b></size> de dados usados";
            }
        }
        else
        {
            Dados.text = "<size=100><b>" + (int)PageControl.Instance.DadosUsados + " KB</b></size> de dados usados";
        }
        if (PageControl.Instance.RedeUsada / 1000f >= 1)
        {
            if ((PageControl.Instance.RedeUsada / 1000f) / 1000f >= 1)
            {
                if (((PageControl.Instance.RedeUsada / 1000f) / 1000f) / 931f >= 1)
                {
                    WiFi.text = "<size=100><b>" + (int)(((PageControl.Instance.RedeUsada / 1000f) / 1000f) / 931f) + " TB</b></size> de rede usada";
                }
                else
                {
                    WiFi.text = "<size=100><b>" + (int)((PageControl.Instance.RedeUsada / 1000f) / 1000f) + " GB</b></size> de rede usada";
                }
            }
            else
            {
                WiFi.text = "<size=100><b>" + (int)(PageControl.Instance.RedeUsada / 1000f) + " MB</b></size> de rede usada";
            }
        }
        else
        {
            WiFi.text = "<size=100><b>" + (int)PageControl.Instance.RedeUsada + " KB</b></size> de rede usada";
        }
    }
}
