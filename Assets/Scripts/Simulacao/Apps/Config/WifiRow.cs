using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WifiRow : MonoBehaviour
{
    public GameObject WifiPass;
    public int RowIndex;
    private string senha;
    private string RedeNome;
    private bool HasPassword;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    [SerializeField]
    private TMPro.TextMeshProUGUI tuxt;

    private void Start()
    {
        HasPassword = PageControl.Instance.RedesDisponiveis[RowIndex].Senha.Length > 0;
        RedeNome = PageControl.Instance.RedesDisponiveis[RowIndex].Nome;
        GameObject inputfield = FindObjectOfType<WifiPass>().gameObject;
        WifiPass = inputfield;
    }
    public void CheckPass()
    {
        AudioManager.Instance.PlaySFX(0);
        if (HasPassword)
        {
            WifiPass.GetComponent<WifiPass>().Link = this;
            WifiPass.GetComponent<WifiPass>().Nome = RedeNome;
            ConfigMaster.PageIndex = 8;
        }
        else
        {
            PageControl.Instance.ConnectToWifi(RowIndex, "", false);
        }
    }
    public void Connect(string _pass)
    {
        senha = _pass;
        PageControl.Instance.ConnectToWifi(RowIndex, senha, true);
    }
    private void Update()
    {
        image.gameObject.SetActive(HasPassword);
        text.text = RedeNome;
        if (PageControl.Instance.RedeConectada == RowIndex)
        {
            tuxt.text = "Conectado";
        }
        else
        {
            tuxt.text = "";
        }
    }
}
