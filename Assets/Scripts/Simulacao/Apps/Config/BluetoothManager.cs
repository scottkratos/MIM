using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BluetoothManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI Nome;
    [SerializeField]
    private TMPro.TextMeshProUGUI Status;
    [SerializeField]
    private GameObject Obj;
    [SerializeField]
    private Slider Slid;
    private float flute;
    [SerializeField]
    private GameObject[] objs;

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
    private void Update()
    {
        Nome.text = PageControl.Instance.BluetoothName;
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(PageControl.Instance.IsBluetoothEnabled);
        }
        if (PageControl.Instance.IsBluetoothEnabled)
        {
            if (flute < 1)
            {
                flute += 0.1f;
            }
            else
            {
                flute = 1;
            }
            Status.text = "Ativado";
        }
        else
        {
            if (flute > 0)
            {
                flute -= 0.1f;
            }
            else
            {
                flute = 0;
            }
            Status.text = "Desativado";
        }
        Slid.value = flute;
    }
    public void ChangeStatus()
    {
        AudioManager.Instance.PlaySFX(0);
        PageControl.Instance.IsBluetoothEnabled = !PageControl.Instance.IsBluetoothEnabled;
    }
}
