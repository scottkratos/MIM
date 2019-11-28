using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsoDeDadosAdvanced : MonoBehaviour
{
    public bool IsWifi;
    public GameObject Prefab;
    public GameObject Child;

    public void Start()
    {
        Child = transform.GetChild(0).gameObject;
    }

    public void  AddApp(App _app)
    {
        GameObject go = Instantiate(Prefab, Child.transform);
        go.GetComponent<AppRow>().IsWifi = IsWifi;
        go.GetComponent<AppRow>()._app = _app;
    }
    public void RemoveApp(App.AppType tipo)
    {
        for (int i = 0; i < Child.transform.childCount; i++)
        {
            if (Child.transform.GetChild(i).GetComponent<AppRow>()._app.Type == tipo)
            {
                Destroy(Child.transform.GetChild(i).gameObject);
                break;
            }
        }
    }
    public void ClearApp()
    {
        for (int i = 0; i < Child.transform.childCount;)
        {
            Destroy(Child.transform.GetChild(i).gameObject);
        }
    }
}
