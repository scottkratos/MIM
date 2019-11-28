using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menssagem : MonoBehaviour
{
    public int Index;
    public string Mensagem;
    public bool Visualized;
    public bool Send;
    [SerializeField]
    private Sprite[] baloes;
    [SerializeField]
    private GameObject[] images;
    [SerializeField]
    private Sprite[] sprites;
    private TMPro.TextMeshProUGUI msg;
    private RectTransform rt;
    private App app;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        msg = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        GetComponent<Image>().sprite = baloes[Index];
        msg.text = Mensagem;
        StartCoroutine(SendMessage());
    }
    private void Update()
    {
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, msg.preferredHeight + 20);
        foreach (AppLocation appu  in PageControl.Instance.homeapps)
        {
            if (appu.App.Name == "WhatsApp") app = appu.App;
        }
        foreach (AppLocation appu in PageControl.Instance.apps)
        {
            if (appu.App.Name == "WhatsApp") app = appu.App;
        }
        images[1].SetActive(Send);
        if (Visualized)
        {
            for(int i = 0; i < images.Length; i++)
            {
                images[i].GetComponent<Image>().sprite = sprites[1];
            }
        }
        else
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].GetComponent<Image>().sprite = sprites[0];
            }
        }
    }
    private IEnumerator SendMessage()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (PageControl.Instance.CanUseInternet(5, app))
            {
                images[0].SetActive(true);
                yield return new WaitForSeconds(1);
                Send = true;
                break;
            }
        }
    }
}
