using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformacoesDoAppManager : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject Child;
    public static InformacoesDoAppManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Spawn()
    {
        for (int i = 0; i < Child.transform.childCount; i++)
        {
            Destroy(Child.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < PageControl.Instance.homeapps.Count; i++)
        {
            GameObject go = Instantiate(Prefab, Child.transform);
            go.GetComponent<InformacoesRow>()._app = PageControl.Instance.homeapps[i].App;
        }
        for (int i = 0; i < PageControl.Instance.apps.Count; i++)
        {
            GameObject go = Instantiate(Prefab, Child.transform);
            go.GetComponent<InformacoesRow>()._app = PageControl.Instance.apps[i].App;
        }
    }
}
