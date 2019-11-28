using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI BateriaText;
    [SerializeField]
    private TMPro.TextMeshProUGUI ArmazenamentoText;

    private void Update()
    {
        BateriaText.text = (int)((PageControl.Instance.Timer / PageControl.Instance.Bateria) * 100) + "% de bateria restante";
        ArmazenamentoText.text = (int)(PageControl.Instance.ArmazenamentoTotalOcupado / PageControl.Instance.ArmazenamentoMaximo) + "% ocupado - " + PageControl.Instance.ArmazenamentoMaximo + "MB livre(s)";
    }
}
