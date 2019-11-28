using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedesManager : MonoBehaviour
{
    [SerializeField]
    private Slider WSlid;
    [SerializeField]
    private Slider PSlider;
    [SerializeField]
    private TMPro.TextMeshProUGUI wifitext;
    [SerializeField]
    private TMPro.TextMeshProUGUI dadostext;
    private float WifiSlider = 0;
    private float PlaneSlider = 0;
    private ConfigMaster Link;

    private void Start()
    {
        Link = FindObjectOfType<ConfigMaster>();
    }
    private void Update()
    {
        if ((PageControl.Instance.DadosUsados + PageControl.Instance.RedeUsada) / 1000f >= 1)
        {
            if ((PageControl.Instance.DadosUsados / 1000f) / 1000f >= 1)
            {
                if (((PageControl.Instance.DadosUsados / 1000f) / 1000f) / 931f >= 1)
                {
                    dadostext.text = (int)((((PageControl.Instance.DadosUsados + PageControl.Instance.RedeUsada) / 1000f) / 1000f) / 931f) + " TB de dados usados";
                }
                else
                {
                    dadostext.text = (int)(((PageControl.Instance.DadosUsados + PageControl.Instance.RedeUsada) / 1000f) / 1000f) + " GB de dados usados";
                }
            }
            else
            {
                dadostext.text = (int)((PageControl.Instance.DadosUsados + PageControl.Instance.RedeUsada) / 1000f) + " MB de dados usados";
            }
        }
        else
        {
            dadostext.text = (int)(PageControl.Instance.DadosUsados + PageControl.Instance.RedeUsada) + " KB de dados usados";
        }
        if (PageControl.Instance.IsWifiEnabled)
        {
            if (WifiSlider < 1)
            {
                WifiSlider += 0.1f;
            }
            else
            {
                WifiSlider = 1;
            }
            if (PageControl.Instance.RedeConectada == -1)
            {
                wifitext.text = "";
            }
            else
            {
                wifitext.text = "Conectado";
            }
        }
        else
        {
            if (WifiSlider > 0)
            {
                WifiSlider -= 0.1f;
            }
            else
            {
                WifiSlider = 0;
            }
            wifitext.text = "Desativado";
        }
        if (PageControl.Instance.IsPlaneModeEnabled)
        {
            if (PlaneSlider < 1)
            {
                PlaneSlider += 0.1f;
            }
            else
            {
                PlaneSlider = 1;
            }
        }
        else
        {
            if (PlaneSlider > 0)
            {
                PlaneSlider -= 0.1f;
            }
            else
            {
                PlaneSlider = 0;
            }
        }
        WSlid.value = WifiSlider;
        PSlider.value = PlaneSlider;
    }

    public void DetectInput(string type)
    {
        PageControl.Instance.OpcoesUpdate(type);
    }
    public void CheckConnection()
    {
        if (PageControl.Instance.IsWifiEnabled)
        {
            Link.EnterSubmenu(7);
        }
    }
}

[System.Serializable]
public class RedeWifi
{
    public string Nome;
    public string Senha;
}
