using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WifiPass : MonoBehaviour
{
    public WifiRow Link;
    public string Nome;

    private void Update()
    {
        transform.GetChild(0).transform.GetChild(3).GetComponent<TMPro.TextMeshProUGUI>().text = Nome;
    }
    public void Connect()
    {
        AudioManager.Instance.PlaySFX(0);
        Link.Connect(GetComponentInChildren<TMPro.TMP_InputField>().text);
        ConfigMaster.PageIndex = 7;
        GetComponentInChildren<TMPro.TMP_InputField>().text = "";
    }
    public void Cancel()
    {
        AudioManager.Instance.PlaySFX(0);
        GetComponentInChildren<TMPro.TMP_InputField>().text = "";
        ConfigMaster.PageIndex = 7;
    }
}
