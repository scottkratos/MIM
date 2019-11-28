using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontoDeAcessoManager : MonoBehaviour
{
    [SerializeField]
    private Slider WSlid;
    [SerializeField]
    private Slider LSlid;
    [SerializeField]
    private Slider RSlid;
    private float WSlider = 0;
    private float LSlider = 0;
    private float RSlider = 0;

    private void Update()
    {
        if (PageControl.Instance.USBTheth)
        {
            if (WSlider < 1)
            {
                WSlider += 0.1f;
            }
            else
            {
                WSlider = 1;
            }
        }
        else
        {
            if (WSlider > 0)
            {
                WSlider -= 0.1f;
            }
            else
            {
                WSlider = 0;
            }
        }
        if (PageControl.Instance.BluetoothTeth)
        {
            if (LSlider < 1)
            {
                LSlider += 0.1f;
            }
            else
            {
                LSlider = 1;
            }
        }
        else
        {
            if (LSlider > 0)
            {
                LSlider -= 0.1f;
            }
            else
            {
                LSlider = 0;
            }
        }
        if (PageControl.Instance.AllowVPN)
        {
            if (RSlider < 1)
            {
                RSlider += 0.1f;
            }
            else
            {
                RSlider = 1;
            }
        }
        else
        {
            if (RSlider > 0)
            {
                RSlider -= 0.1f;
            }
            else
            {
                RSlider = 0;
            }
        }
        WSlid.value = WSlider;
        LSlid.value = LSlider;
        RSlid.value = RSlider;
    }
    public void ChangeInstance(int i)
    {
        AudioManager.Instance.PlaySFX(0);
        switch (i)
        {
            case 0:
                PageControl.Instance.USBTheth = !PageControl.Instance.USBTheth;
                break;
            case 1:
                PageControl.Instance.BluetoothTeth = !PageControl.Instance.BluetoothTeth;
                break;
            case 2:
                PageControl.Instance.AllowVPN = !PageControl.Instance.AllowVPN;
                break;
        }
    }
}

[System.Serializable]
public class PontoDeAcessoWifi
{
    public bool IsActivated;
    public string Nome;
    public Seguranca Seg;
    public string Senha;

    public enum Seguranca
    {
        Nenhuma,
        WEP,
        WPA2PSK
    }
}