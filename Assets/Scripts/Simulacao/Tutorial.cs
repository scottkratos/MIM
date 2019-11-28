using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public CreateTutorial[] Tut;
    private GameObject Child;

    private void Start()
    {
        Child = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (PageControl.Instance.IsActive)
        {
            for (int r = 0; r < Tut.Length; r++)
            {
                if (Tut[r].IsMkt)
                {
                    if (GameState.Instance.PowerUpsActive[3])
                    {
                        if (Tut[r].Linked == PageControl.Instance.minigame)
                        {
                            for (int i = 0; i < Tut[r].Index.Length; i++)
                            {
                                if (Tut[r].Index[i] - 1 >= 0)
                                {
                                    if (PageControl.Instance.Objectives[Tut[r].Index[i] - 1])
                                    {
                                        if (!PageControl.Instance.Objectives[Tut[r].Index[i]])
                                        {
                                            Child.SetActive(true);
                                        }
                                        else
                                        {
                                            Child.SetActive(false);
                                        }
                                    }
                                    else
                                    {
                                        Child.SetActive(false);
                                    }
                                }
                                else
                                {
                                    if (!PageControl.Instance.Objectives[Tut[r].Index[i]])
                                    {
                                        Child.SetActive(true);
                                    }
                                    else
                                    {
                                        Child.SetActive(false);
                                    }
                                }
                            }
                            break;
                        }
                        else
                        {
                            Child.SetActive(false);
                        }
                    }
                    else return;
                }
                else
                {
                    if (Tut[r].Linked == PageControl.Instance.minigame)
                    {
                        for (int i = 0; i < Tut[r].Index.Length; i++)
                        {
                            if (Tut[r].Index[i] - 1 >= 0)
                            {
                                if (PageControl.Instance.Objectives[Tut[r].Index[i] - 1])
                                {
                                    if (!PageControl.Instance.Objectives[Tut[r].Index[i]])
                                    {
                                        Child.SetActive(true);
                                    }
                                    else
                                    {
                                        Child.SetActive(false);
                                    }
                                }
                                else
                                {
                                    Child.SetActive(false);
                                }
                            }
                            else
                            {
                                if (!PageControl.Instance.Objectives[Tut[r].Index[i]])
                                {
                                    Child.SetActive(true);
                                }
                                else
                                {
                                    Child.SetActive(false);
                                }
                            }
                        }
                        break;
                    }
                    else
                    {
                        Child.SetActive(false);
                    }
                }
            }
        }
        else
        {
            Child.SetActive(false);
        }
    }
}
[System.Serializable]
public class CreateTutorial
{
    public bool IsMkt;
    public GameState.Minigames Linked;
    public int[] Index;
}
