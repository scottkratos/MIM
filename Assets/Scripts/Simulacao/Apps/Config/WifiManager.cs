using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiManager : MonoBehaviour
{
    public GameObject Prefab;
    public static WifiManager Instance;
    private GameObject Child;

    private void Awake()
    {
        Child = transform.GetChild(0).gameObject;
        Instance = this;
    }

    public void CreateRows()
    {
        for (int i = 0; i < Child.transform.childCount; i++)
        {
            Destroy(Child.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < PageControl.Instance.RedesDisponiveis.Length; i++)
        {
            GameObject waa = Instantiate(Prefab, Child.transform);
            waa.GetComponent<WifiRow>().RowIndex = i;
        }
    }
}
