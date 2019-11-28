using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaveta : MonoBehaviour
{
    public static Gaveta Instance;
    [SerializeField]
    public GameObject Prefab;
    public GameObject Child;

    private void Awake()
    {
        Instance = this;
        Child = transform.GetChild(0).gameObject;
    }

    public void UpdateApps()
    {
        for (int i = 0; i < Child.transform.childCount; i++)
        {
            Destroy(Child.transform.GetChild(i).gameObject);
        }
        foreach (App _app in PageControl.Instance.AllApps)
        {
            GameObject Ob = Instantiate(Prefab, Child.transform);
            FakeApp Comp = Ob.GetComponent<FakeApp>();
            Comp.Image = _app.Image;
            Comp.Name = _app.Name;
            Comp.Type = _app.Type;
        }
    }
}
