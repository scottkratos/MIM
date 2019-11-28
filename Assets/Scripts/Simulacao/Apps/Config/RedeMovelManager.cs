using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedeMovelManager : MonoBehaviour
{
    [SerializeField]
    private Slider DSlid;
    private float DadosSlider = 0;

    private void Update()
    {
        if (PageControl.Instance.IsDadosEnabled)
        {
            if (DadosSlider < 1)
            {
                DadosSlider += 0.1f;
            }
            else
            {
                DadosSlider = 1;
            }
        }
        else
        {
            if (DadosSlider > 0)
            {
                DadosSlider -= 0.1f;
            }
            else
            {
                DadosSlider = 0;
            }
        }
        DSlid.value = DadosSlider;
    }

    public void DetectInput(string type)
    {
        PageControl.Instance.OpcoesUpdate(type);
    }
}
