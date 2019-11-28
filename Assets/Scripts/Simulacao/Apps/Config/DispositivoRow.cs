using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispositivoRow : MonoBehaviour
{
    public string Nome;
    public bool Status;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    [SerializeField]
    private TMPro.TextMeshProUGUI stats;

    private void Start()
    {
        text.text = Nome;
    }
    private void Update()
    {
        if (Status)
        {
            stats.text = "Conectado";
        }
        else
        {
            stats.text = "";
        }
    }
    public void ChangeStatus()
    {
        AudioManager.Instance.PlaySFX(0);
        Status = !Status;
        foreach (DispositivosBluetooth dis in PageControl.Instance.DisBluetooth)
        {
            if (dis.Name == Nome)
            {
                dis.Status = !dis.Status;
            }
        }
    }
}
