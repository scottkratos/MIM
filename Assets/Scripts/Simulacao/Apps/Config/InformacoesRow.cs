using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformacoesRow : MonoBehaviour
{
    public App _app;
    private InformacoesDoAppAdvanced Link;
    private ConfigMaster Lonk;
    [SerializeField]
    private TMPro.TextMeshProUGUI Titulo;
    [SerializeField]
    private TMPro.TextMeshProUGUI Desc;
    [SerializeField]
    private Image Icon;

    private void Start()
    {
        Titulo.text = _app.Name;
        Icon.sprite = _app.Image;
        Link = FindObjectOfType<InformacoesDoAppAdvanced>();
        Lonk = FindObjectOfType<ConfigMaster>();
    }
    public void PassInfo()
    {
        AudioManager.Instance.PlaySFX(0);
        Link.app = _app;
        Link.Create();
        Lonk.EnterSubmenu(24);
    }
}
