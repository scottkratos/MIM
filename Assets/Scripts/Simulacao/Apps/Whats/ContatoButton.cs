using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContatoButton : MonoBehaviour
{
    public int ID;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TMPro.TextMeshProUGUI nome;
    [SerializeField]
    private TMPro.TextMeshProUGUI desc;

    private void Start()
    {
        nome.text = PageControl.Instance.Contatos[ID].Name;
        desc.text = PageControl.Instance.Contatos[ID].Desc;
        image.sprite = PageControl.Instance.Contatos[ID].Thumbnail;
    }

    public void OpenConv()
    {
        MessagesManager.Instance.CreateConversation(ID);
        WhatsConfg.Instance.EnterSubmenu(3);
    }
}