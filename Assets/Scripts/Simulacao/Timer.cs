using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    [SerializeField]
    private TMPro.TextMeshProUGUI porcent;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        if (text != null)
        {
            if (DateTime.Now.Minute.ToString().Length > 1)
            {
                text.text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            }
            else
            {
                text.text = DateTime.Now.Hour + ":0" + DateTime.Now.Minute;
            }
        }
        slider.value = PageControl.Instance.Timer / PageControl.Instance.Bateria;
        porcent.text = (int)((PageControl.Instance.Timer / PageControl.Instance.Bateria) * 100) + "%";
    }
}
