using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParearDispositivoManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI Nome;
    [SerializeField]
    private GameObject Prefab;
    [SerializeField]
    private GameObject Child;
    [SerializeField]
    private GameObject Obj;

    private void Start()
    {
        for (int i = 0; i < PageControl.Instance.DisBluetooth.Length; i++)
        {
            GameObject go = Instantiate(Prefab, Child.transform);
            go.GetComponent<DispositivoRow>().Nome = PageControl.Instance.DisBluetooth[i].Name;
            go.GetComponent<DispositivoRow>().Status = PageControl.Instance.DisBluetooth[i].Status;
        }
    }
    private void Update()
    {
        Nome.text = PageControl.Instance.BluetoothName;
    }
    public void EnterName()
    {
        AudioManager.Instance.PlaySFX(0);
        PageControl.Instance.BluetoothName = Obj.GetComponentInChildren<TMPro.TMP_InputField>().text;
        Obj.SetActive(false);
    }
    public void RemoveName()
    {
        AudioManager.Instance.PlaySFX(0);
        Obj.SetActive(false);
    }
    public void StartObj()
    {
        AudioManager.Instance.PlaySFX(0);
        Obj.GetComponentInChildren<TMPro.TMP_InputField>().text = PageControl.Instance.BluetoothName;
        Obj.SetActive(true);
    }
}
