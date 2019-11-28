using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [Header("Constantes:")]
    public int ID;
    public List<Slot> slots = new List<Slot>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            slots.Add(transform.GetChild(i).GetComponent<Slot>());
        }
    }
}
