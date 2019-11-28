using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavBar : MonoBehaviour
{
    public GameObject Child;

    private void Update()
    {
        bool IsActive = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject != Child)
            {
                if (transform.GetChild(i).gameObject.activeSelf)
                {
                    IsActive = true;
                }
            }
        }
        Child.SetActive(IsActive);
    }
}
