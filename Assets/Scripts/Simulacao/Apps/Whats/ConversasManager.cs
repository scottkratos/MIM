using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Child;
    [SerializeField]
    private GameObject Prefab;
    private int LastIndex = -1;

    private void Update()
    {
        if (WhatsConfg.PageIndex == 0 && LastIndex != WhatsConfg.PageIndex)
        {
            for (int i = 0; i < Child.transform.childCount; i++)
            {
                Destroy(Child.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < PageControl.Instance.Contatos.Length; i++)
            {
                GameObject GO = Instantiate(Prefab, Child.transform);
                GO.GetComponent<ContatoButton>().ID = i;
            }
        }
        LastIndex = WhatsConfg.PageIndex;
    }
}
