using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontoDeAcessoWifiManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Name;
    public TMPro.TextMeshProUGUI Seguranca;
    public TMPro.TextMeshProUGUI Pass;
    public GameObject RowPass;
    public TMPro.TMP_InputField Nfield;
    public TMPro.TMP_InputField Pfield;
    public GameObject[] Objects;
    public Toggle[] toggles;


    public void RemovePass(int i)
    {
        AudioManager.Instance.PlaySFX(0);
        Objects[i].SetActive(false);
    }
    public void EnterPass(int i)
    {
        AudioManager.Instance.PlaySFX(0);
        switch (i)
        {
            case 0:
                PageControl.Instance.PontoDeAcesso.Nome = Nfield.text;
                break;
            case 1:
                PageControl.Instance.PontoDeAcesso.Senha = Pfield.text;
                break;
            case 2:
                for (int r = 0; r < toggles.Length; r++)
                {
                    if (toggles[r].isOn)
                    {
                        Lista(r);
                        break;
                    }
                }
                break;
        }
        Objects[i].SetActive(false);
    }
    public void StartObjects(int i)
    {
        AudioManager.Instance.PlaySFX(0);
        switch (i)
        {
            case 0:
                Nfield.text = PageControl.Instance.PontoDeAcesso.Nome;
                break;
            case 1:
                Pfield.text = PageControl.Instance.PontoDeAcesso.Senha;
                break;
            case 2:
                UpdateGroup();
                break;
        }
        Objects[i].SetActive(true);
    }
    private void Update()
    {
        switch (PageControl.Instance.PontoDeAcesso.Seg)
        {
            case PontoDeAcessoWifi.Seguranca.Nenhuma:
                RowPass.SetActive(false);
                break;
            default:
                RowPass.SetActive(true);
                break;
        }
        switch (PageControl.Instance.PontoDeAcesso.Seg)
        {
            case PontoDeAcessoWifi.Seguranca.Nenhuma:
                Seguranca.text = "Nenhuma";
                break;
            case PontoDeAcessoWifi.Seguranca.WEP:
                Seguranca.text = "WEP";
                break;
            case PontoDeAcessoWifi.Seguranca.WPA2PSK:
                Seguranca.text = "WPA2 PSK";
                break;
        }
        Name.text = PageControl.Instance.PontoDeAcesso.Nome;
        string vodka = ".";
        for (int i = 0; i < PageControl.Instance.PontoDeAcesso.Senha.Length; i++)
        {
            vodka = vodka + ".";
        }
        Pass.text = vodka;
    }
    public void Lista(int i)
    {
        switch(i)
        {
            case 0:
                PageControl.Instance.PontoDeAcesso.Seg = PontoDeAcessoWifi.Seguranca.Nenhuma;
                break;
            case 1:
                PageControl.Instance.PontoDeAcesso.Seg = PontoDeAcessoWifi.Seguranca.WEP;
                break;
            case 2:
                PageControl.Instance.PontoDeAcesso.Seg = PontoDeAcessoWifi.Seguranca.WPA2PSK;
                break;
        }
    }

    public void UpdateGroup()
    {
        switch (PageControl.Instance.PontoDeAcesso.Seg)
        {
            case PontoDeAcessoWifi.Seguranca.Nenhuma:
                toggles[0].isOn = true;
                toggles[1].isOn = false;
                toggles[2].isOn = false;
                break;
            case PontoDeAcessoWifi.Seguranca.WEP:
                toggles[0].isOn = false;
                toggles[1].isOn = true;
                toggles[2].isOn = false;
                break;
            case PontoDeAcessoWifi.Seguranca.WPA2PSK:
                toggles[0].isOn = false;
                toggles[1].isOn = false;
                toggles[2].isOn = true;
                break;
        }
    }
}
