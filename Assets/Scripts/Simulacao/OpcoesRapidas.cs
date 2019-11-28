using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpcoesRapidas : MonoBehaviour
{
    public Sprite[] sprites;
    public string Type;
    [SerializeField]
    private Image image;

    private void Update()
    {
        switch (GameState.Instance.CT)
        {
            case GameState.CelType.Google:
                switch (Type)
                {
                    case "Wifi":
                        if (PageControl.Instance.IsWifiEnabled) image.sprite = sprites[1];
                        else image.sprite = sprites[0];
                        break;
                    case "GPS":
                        if (PageControl.Instance.IsGPSEnabled) image.sprite = sprites[1];
                        else image.sprite = sprites[0];
                        break;
                    case "Bluetooth":
                        if (PageControl.Instance.IsBluetoothEnabled) image.sprite = sprites[1];
                        else image.sprite = sprites[0];
                        break;
                    case "Dados":
                        if (PageControl.Instance.IsDadosEnabled) image.sprite = sprites[1];
                        else image.sprite = sprites[0];
                        break;
                    case "Energy":
                        if (PageControl.Instance.IsEnergyEnabled) image.sprite = sprites[1];
                        else image.sprite = sprites[0];
                        break;
                    case "Plane":
                        if (PageControl.Instance.IsPlaneModeEnabled) image.sprite = sprites[1];
                        else image.sprite = sprites[0];
                        break;
                    case "Light":
                        if (PageControl.Instance.IsLightEnabled) image.sprite = sprites[1];
                        else image.sprite = sprites[0];
                        break;
                }
                break;
            case GameState.CelType.LG:
                switch (Type)
                {
                    case "Wifi":
                        if (PageControl.Instance.IsWifiEnabled) image.sprite = sprites[2];
                        else image.sprite = sprites[0];
                        break;
                    case "GPS":
                        if (PageControl.Instance.IsGPSEnabled) image.sprite = sprites[2];
                        else image.sprite = sprites[0];
                        break;
                    case "Bluetooth":
                        if (PageControl.Instance.IsBluetoothEnabled) image.sprite = sprites[2];
                        else image.sprite = sprites[0];
                        break;
                    case "Dados":
                        if (PageControl.Instance.IsDadosEnabled) image.sprite = sprites[2];
                        else image.sprite = sprites[0];
                        break;
                    case "Energy":
                        if (PageControl.Instance.IsEnergyEnabled) image.sprite = sprites[2];
                        else image.sprite = sprites[0];
                        break;
                    case "Plane":
                        if (PageControl.Instance.IsPlaneModeEnabled) image.sprite = sprites[2];
                        else image.sprite = sprites[0];
                        break;
                    case "Light":
                        if (PageControl.Instance.IsLightEnabled) image.sprite = sprites[2];
                        else image.sprite = sprites[0];
                        break;
                }
                break;
            case GameState.CelType.Samsung:
                switch (Type)
                {
                    case "Wifi":
                        if (PageControl.Instance.IsWifiEnabled) image.sprite = sprites[3];
                        else image.sprite = sprites[0];
                        break;
                    case "GPS":
                        if (PageControl.Instance.IsGPSEnabled) image.sprite = sprites[3];
                        else image.sprite = sprites[0];
                        break;
                    case "Bluetooth":
                        if (PageControl.Instance.IsBluetoothEnabled) image.sprite = sprites[3];
                        else image.sprite = sprites[0];
                        break;
                    case "Dados":
                        if (PageControl.Instance.IsDadosEnabled) image.sprite = sprites[3];
                        else image.sprite = sprites[0];
                        break;
                    case "Energy":
                        if (PageControl.Instance.IsEnergyEnabled) image.sprite = sprites[3];
                        else image.sprite = sprites[0];
                        break;
                    case "Plane":
                        if (PageControl.Instance.IsPlaneModeEnabled) image.sprite = sprites[3];
                        else image.sprite = sprites[0];
                        break;
                    case "Light":
                        if (PageControl.Instance.IsLightEnabled) image.sprite = sprites[3];
                        else image.sprite = sprites[0];
                        break;
                }
                break;
        }
    }

    public void UpateOption()
    {
        PageControl.Instance.OpcoesUpdate(Type);
    }
}
