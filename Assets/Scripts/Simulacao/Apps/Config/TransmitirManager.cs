using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmitirManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab;
    [SerializeField]
    private GameObject Child;
    public static TransmitirManager Instance;

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
        for (int i = 0; i < PageControl.Instance.DisBluetooth.Length; i++)
        {
            GameObject go = Instantiate(Prefab, Child.transform);
            go.GetComponent<DispositivoRow>().Nome = PageControl.Instance.DisBluetooth[i].Name;
            go.GetComponent<DispositivoRow>().Status = PageControl.Instance.DisBluetooth[i].Status;
        }
    }
}
