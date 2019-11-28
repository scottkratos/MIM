using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LojaManager : MonoBehaviour
{
    public static Coroutine[] AvaiableCorots = new Coroutine[4];
    public GameObject[] Buttons;
    public bool[] CanBeActive = new bool[2] { true, true };

    public void Buy(int index)
    {
        GameState.Instance.PowerUpsCount[index]++;
        GameState.Instance.Save();
    }
    public void Use(int index)
    {
        if (GameState.Instance.PowerUpsCount[index] > 0)
        {
            GameState.Instance.PowerUpsCount[index]--;
            GameState.Instance.PowerUpsActive[index] = true;
            switch(index)
            {
                case 0:
                    GameState.Instance.timer[index] += 1800;
                    break;
                case 1:
                    GameState.Instance.timer[index] += 1800;
                    break;
                case 2:
                    GameState.Instance.timer[index] += 900;
                    break;
                case 3:
                    GameState.Instance.timer[index] += 300;
                    break;
            }
            if (AvaiableCorots[index] == null) AvaiableCorots[index] = StartCoroutine(GameState.Instance.DelayToFinish(index));
        }
        GameState.Instance.Save();
    }
    public void ChangeState(int index)
    {
        switch(index)
        {
            case 0:
                if(!GameState.Instance.HasLoja)
                {
                    GameState.Instance.HasLoja = true;
                    GameState.Instance.StartMascote(GameState.Instance.loja);
                    GameState.Instance.Save();
                }
                break;
            case 1:
                if (!GameState.Instance.HasInvent)
                {
                    GameState.Instance.HasInvent = true;
                    GameState.Instance.StartMascote(GameState.Instance.invent);
                    GameState.Instance.Save();
                }
                break;
        }
        CanBeActive[index] = !CanBeActive[index];
    }
    private void Update()
    {
        if (PageControl.Instance != null)
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].SetActive(!GameState.Instance.SimActivated && !PageControl.Instance.IsActive && CanBeActive[i]);
            }
        }
        else
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].SetActive(!GameState.Instance.SimActivated && CanBeActive[i]);
            }
        }
    }
}
