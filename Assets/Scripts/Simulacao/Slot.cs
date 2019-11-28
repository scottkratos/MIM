using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool IsFilled;
    public int ID;

    private void Update()
    {
        IsFilled = transform.childCount > 0;
    }
}
