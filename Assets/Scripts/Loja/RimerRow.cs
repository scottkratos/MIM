using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimerRow : MonoBehaviour
{
    public int Index;
    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    private void Update()
    {
        if (GameState.Instance.timer[Index] / 60 > 0)
        {
            if ((GameState.Instance.timer[Index] / 60) / 60 > 0)
            {
                text.text = ((GameState.Instance.timer[Index] / 60) /60) + ":" + (((GameState.Instance.timer[Index] / 60) - (((GameState.Instance.timer[Index] / 60) / 60) * 60)) + ":" + (GameState.Instance.timer[Index] - (((GameState.Instance.timer[Index] / 60) * 60))));
            }
            else
            {
                text.text = (GameState.Instance.timer[Index] / 60) + ":" + ((GameState.Instance.timer[Index]) - ((GameState.Instance.timer[Index] / 60) * 60));
            }
        }
        else
        {
            text.text = GameState.Instance.timer[Index].ToString();
        }
    }
}
