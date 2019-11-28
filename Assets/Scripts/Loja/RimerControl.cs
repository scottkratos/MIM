using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimerControl : MonoBehaviour
{
    public GameObject[] Childs;

    private void Update()
    {
        for(int i = 0; i < Childs.Length; i++)
        {
            if (PageControl.Instance == null) Childs[i].SetActive(GameState.Instance.PowerUpsActive[i] && !GameState.Instance.SimActivated);
            else Childs[i].SetActive(GameState.Instance.PowerUpsActive[i] && !PageControl.Instance.IsActive && !GameState.Instance.SimActivated);
        }
    }
}
