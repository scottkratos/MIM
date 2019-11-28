using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenderRow : MonoBehaviour
{
    public string Nome;

    private void Start()
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = Nome;
    }
}
