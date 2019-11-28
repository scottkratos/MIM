using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmazenamentoDisplayManager : MonoBehaviour
{
    public App.DataType type;
    public GameObject Prefab;
    public GameObject Child;
    public static List<ArmazenamentoDisplayManager> Instances = new List<ArmazenamentoDisplayManager>();

    private void Awake()
    {
        Instances.Add(this);
    }
    public void Spawn()
    {
        for (int i = 0; i < Child.transform.childCount; i++)
        {
            Destroy(Child.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < PageControl.Instance.homeapps.Count; i++)
        {
            if (PageControl.Instance.homeapps[i].App.dataType == type)
            {
                GameObject go = Instantiate(Prefab, Child.transform);
                go.GetComponent<ArmazenRow>().Nome = PageControl.Instance.homeapps[i].App.Name;
                go.GetComponent<ArmazenRow>().Type = PageControl.Instance.homeapps[i].App.dataType;
                go.GetComponent<ArmazenRow>().Size = PageControl.Instance.homeapps[i].App.Size;
                go.GetComponent<ArmazenRow>().app = PageControl.Instance.homeapps[i].App;
                go.GetComponent<ArmazenRow>().ibagem.sprite = PageControl.Instance.homeapps[i].App.Image;
                go.GetComponent<ArmazenRow>().IsApp = true;
            }
        }
        for (int i = 0; i < PageControl.Instance.apps.Count; i++)
        {
            if (PageControl.Instance.apps[i].App.dataType == type)
            {
                GameObject go = Instantiate(Prefab, Child.transform);
                go.GetComponent<ArmazenRow>().Nome = PageControl.Instance.apps[i].App.Name;
                go.GetComponent<ArmazenRow>().Type = PageControl.Instance.apps[i].App.dataType;
                go.GetComponent<ArmazenRow>().Size = PageControl.Instance.apps[i].App.Size;
                go.GetComponent<ArmazenRow>().app = PageControl.Instance.apps[i].App;
                go.GetComponent<ArmazenRow>().ibagem.sprite = PageControl.Instance.apps[i].App.Image;
                go.GetComponent<ArmazenRow>().IsApp = true;
            }
        }
        for (int i = 0; i < PageControl.Instance.Arquivos.Count; i++)
        {
            if (PageControl.Instance.Arquivos[i].Data == type)
            {
                GameObject go = Instantiate(Prefab, Child.transform);
                go.GetComponent<ArmazenRow>().Nome = PageControl.Instance.Arquivos[i].Nome;
                go.GetComponent<ArmazenRow>().Type = PageControl.Instance.Arquivos[i].Data;
                go.GetComponent<ArmazenRow>().Size = PageControl.Instance.Arquivos[i].Peso;
                go.GetComponent<ArmazenRow>().ibagem.sprite = PageControl.Instance.Arquivos[i].Thumbnail;
                go.GetComponent<ArmazenRow>().IsApp = false;
            }
        }
    }
}
