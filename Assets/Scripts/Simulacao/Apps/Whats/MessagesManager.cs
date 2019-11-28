using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagesManager : MonoBehaviour
{
    public static MessagesManager Instance;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TMPro.TextMeshProUGUI Name;
    [SerializeField]
    private GameObject Child;
    [SerializeField]
    private GameObject Prefab;
    [SerializeField]
    private TMPro.TMP_InputField inFild;
    public List<WhatsAppControl> Contatos = new List<WhatsAppControl>();
    private int LastIndex;

    private void Awake()
    {
        Instance = this;
    }

    public void CreateConversation(int index)
    {
        LastIndex = index;
        Name.text = PageControl.Instance.Contatos[index].Name;
        image.sprite = PageControl.Instance.Contatos[index].Thumbnail;
        for (int i = 0; i < Child.transform.childCount; i++)
        {
            Destroy(Child.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < Contatos[index].RecivedMessages.Count; i++)
        {
            GameObject GO = Instantiate(Prefab, Child.transform);
            GO.GetComponent<Menssagem>().Mensagem = Contatos[index].RecivedMessages[i].Message;
            GO.GetComponent<Menssagem>().Index = Contatos[index].RecivedMessages[i].Sender;
        }
    }

    public void ButtonToConv()
    {
        AddToConversation(0, "");
    }
    public void AddToConversation(int sender, string text)
    {
        GameObject GO = Instantiate(Prefab, Child.transform);
        MessageControl wp = new MessageControl();
        wp.Sender = sender;
        if (sender == 0)
        {
            GO.GetComponent<Menssagem>().Mensagem = inFild.text;
            wp.Message = inFild.text;
            inFild.text = "";
        }
        else
        {
            GO.GetComponent<Menssagem>().Mensagem = text;
            wp.Message = text;
        }
        GO.GetComponent<Menssagem>().Index = sender;
        Contatos[LastIndex].RecivedMessages.Add(wp);
    }
    public void AddLists()
    {
        Contatos.Clear();
        for (int i = 0; i < PageControl.Instance.Contatos.Length; i++)
        {
            WhatsAppControl wpp = new WhatsAppControl();
            wpp.Desc = PageControl.Instance.Contatos[i].Desc;
            wpp.Name = PageControl.Instance.Contatos[i].Name;
            List<MessageControl> mc = new List<MessageControl>();
            for (int r = 0; r < PageControl.Instance.Contatos[i].RecivedMessages.Count; r++)
            {
                MessageControl locmc = new MessageControl();
                locmc.Message = PageControl.Instance.Contatos[i].RecivedMessages[r].Message;
                locmc.Sender = PageControl.Instance.Contatos[i].RecivedMessages[r].Sender;
                mc.Add(locmc);
            }
            wpp.RecivedMessages = mc;
            wpp.Thumbnail = PageControl.Instance.Contatos[i].Thumbnail;
            Contatos.Add(wpp);
        }
    }
}
