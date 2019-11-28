using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightIllusion : MonoBehaviour
{
    [SerializeField]
    private Slider Ref;
    private Slider Link;

    private void Start()
    {
        Link = GetComponent<Slider>();
    }
    private void Update()
    {
        Link.value = Ref.value;
    }
}
