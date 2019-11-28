using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LojaRow : MonoBehaviour
{
    public int Index;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    private void Update()
    {
        text.text = "Possuido: " + GameState.Instance.PowerUpsCount[Index];
    }
}
