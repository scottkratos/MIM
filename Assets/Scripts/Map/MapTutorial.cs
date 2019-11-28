using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTutorial : MonoBehaviour
{
    public Level Reference;

    private void Start()
    {
        Reference = GetComponentInParent<MacroLevel>().level;
    }
}
