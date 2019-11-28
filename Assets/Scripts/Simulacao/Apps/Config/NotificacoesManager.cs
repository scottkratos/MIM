using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificacoesManager : MonoBehaviour
{
    [SerializeField]
    private Slider WSlid;
    private float PlaneSlider;

    private void Update()
    {
        if (PageControl.Instance.IsNotifyEnabled)
        {
            if (PlaneSlider < 1)
            {
                PlaneSlider += 0.1f;
            }
            else
            {
                PlaneSlider = 1;
            }
        }
        else
        {
            if (PlaneSlider > 0)
            {
                PlaneSlider -= 0.1f;
            }
            else
            {
                PlaneSlider = 0;
            }
        }
        WSlid.value = PlaneSlider;
    }
    public void ChangeStatus()
    {
        AudioManager.Instance.PlaySFX(0);
        PageControl.Instance.IsNotifyEnabled = !PageControl.Instance.IsNotifyEnabled;
    }
}
