using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigMaster : MonoBehaviour
{
    public static int PageIndex = 0;
    public TMPro.TextMeshProUGUI HeaderText;
    public GameObject HeaderButton;
    public GameObject[] Submenus;

    public void EnterSubmenu(int value)
    {
        AudioManager.Instance.PlaySFX(0);
        PageIndex = value;
    }

    public void Return()
    {
        AudioManager.Instance.PlaySFX(0);
        switch (PageIndex)
        {
            case 0:
                PageControl.Instance.MacroIndex = 0;
                break;
            case 1:
                PageIndex = 0;
                break;
            case 2:
                PageIndex = 0;
                break;
            case 3:
                PageIndex = 0;
                break;
            case 4:
                PageIndex = 0;
                break;
            case 5:
                PageIndex = 0;
                break;
            case 6:
                PageIndex = 0;
                break;
            case 7:
                PageIndex = 1;
                break;
            case 8:
                PageIndex = 7;
                break;
            case 9:
                PageIndex = 1;
                break;
            case 10:
                PageIndex = 1;
                break;
            case 11:
                PageIndex = 10;
                break;
            case 12:
                PageIndex = 10;
                break;
            case 13:
                PageIndex = 1;
                break;
            case 14:
                PageIndex = 13;
                break;
            case 15:
                PageIndex = 1;
                break;
            case 16:
                PageIndex = 15;
                break;
            case 17:
                PageIndex = 1;
                break;
            case 18:
                PageIndex = 2;
                break;
            case 19:
                PageIndex = 2;
                break;
            case 20:
                PageIndex = 19;
                break;
            case 21:
                PageIndex = 19;
                break;
            case 22:
                PageIndex = 19;
                break;
            case 23:
                PageIndex = 3;
                break;
            case 24:
                PageIndex = 23;
                break;
            case 25:
                PageIndex = 3;
                break;
            case 26:
                PageIndex = 25;
                break;
            case 27:
                PageIndex = 5;
                break;
            case 28:
                PageIndex = 6;
                break;
            case 29:
                PageIndex = 6;
                break;
            case 30:
                PageIndex = 6;
                break;
            case 31:
                PageIndex = 6;
                break;
            case 32:
                PageIndex = 6;
                break;
        }
    }

    private void Update()
    {
        switch (PageIndex)
        {
            case 0:
                HeaderText.text = "Configurações";
                HeaderButton.SetActive(false);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 0)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 1:
                HeaderText.text = "Rede e internet";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 1)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 2:
                HeaderText.text = "Dispositivos conectados";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 2)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 3:
                HeaderText.text = "Apps e notificações";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 3)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 4:
                HeaderText.text = "Bateria";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 4)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 5:
                HeaderText.text = "Tela";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 5)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 6:
                HeaderText.text = "Armazenamento";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 6)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 7:
                HeaderText.text = "Wi-Fi";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 7)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 8:
                HeaderText.text = "Wi-Fi";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 8)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 9:
                HeaderText.text = "Rede móvel";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 9)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 10:
                HeaderText.text = "Uso de dados";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 10)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 11:
                HeaderText.text = "Uso de dados Wi-Fi";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 11)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 12:
                HeaderText.text = "Uso de dados móveis";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 12)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 13:
                HeaderText.text = "Ponto de acesso e tethering";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 13)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 14:
                HeaderText.text = "Ponto de acesso Wi-Fi";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 14)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 15:
                HeaderText.text = "VPN";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 15)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 16:
                HeaderText.text = "VPN";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 16)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 17:
                HeaderText.text = "DNS";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 17)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 18:
                HeaderText.text = "Parear novo dispositivos";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 18)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 19:
                HeaderText.text = "Preferências de conexão";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 19)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 20:
                HeaderText.text = "Bluetooth";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 20)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 21:
                HeaderText.text = "Transmitir";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 21)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 22:
                HeaderText.text = "Bluetooth Recebido";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 22)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 23:
                HeaderText.text = "Informações do app";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 23)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 24:
                HeaderText.text = "Informações do app";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 24)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 25:
                HeaderText.text = "Notificações";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 25)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 26:
                HeaderText.text = "Notificações";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 26)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 27:
                HeaderText.text = "Tela";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 27 || i == 5)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 28:
                HeaderText.text = "Fotos e vídeos";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 28)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 29:
                HeaderText.text = "Música e áudio";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 29)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 30:
                HeaderText.text = "Jogos";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 30)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 31:
                HeaderText.text = "Apps de Filmes e TV";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 31)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 32:
                HeaderText.text = "Outros apps";
                HeaderButton.SetActive(true);
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 32)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
        }
    }
}
