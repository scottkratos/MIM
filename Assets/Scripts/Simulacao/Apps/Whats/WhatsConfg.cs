using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatsConfg : MonoBehaviour
{
    public static int PageIndex = 0;
    public static WhatsConfg Instance;
    public GameObject[] Submenus;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        switch (PageIndex)
        {
            case 0:
                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 0)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 1:

                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 1)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 2:

                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 2)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
            case 3:

                for (int i = 0; i < Submenus.Length; i++)
                {
                    if (i == 3)
                    {
                        Submenus[i].SetActive(true);
                    }
                    else
                    {
                        Submenus[i].SetActive(false);
                    }
                }
                break;
        }

    }
    public void EnterSubmenu(int value)
    {
        AudioManager.Instance.PlaySFX(0);
        PageIndex = value;
    }
}
