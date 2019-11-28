using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrilhoManager : MonoBehaviour
{
    [SerializeField]
    private Slider sliderRef;
    [SerializeField]
    private Slider sliderMaster;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;
    private bool Lock;

    private void Update()
    {
        if (sliderRef.gameObject.activeSelf && !Lock)
        {
            sliderRef.value = sliderMaster.value;
            Lock = true;
        }
        else if (!sliderRef.gameObject.activeSelf)
        {
            Lock = false;
        }
        sliderMaster.value = sliderRef.value;
        text.text = Mathf.Abs((int)(((sliderMaster.value / -80) - 1) * 100)) + "%";
    }
}
