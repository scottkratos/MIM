using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGiveway : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public GameObject[] Images;

    public void Generate()
    {
        for (int i = 0; i < Images.Length; i++)
        {
            Images[i].SetActive(false);
        }
        int result;
        result = Random.Range(0, 101);
        if (result >= 10)
        {
            text.text = "Mão Guia";
            Images[3].SetActive(true);
            GameState.Instance.PowerUpsCount[3]++;
        }
        else if (result < 10 && result >= 40)
        {
            text.text = "Rede Livre";
            Images[2].SetActive(true);
            GameState.Instance.PowerUpsCount[2]++;
        }
        else if (result < 40 && result >= 70)
        {
            text.text = "Dados Extras";
            Images[1].SetActive(true);
            GameState.Instance.PowerUpsCount[1]++;
        }
        else
        {
            text.text = "Bateria Extra";
            Images[0].SetActive(true);
            GameState.Instance.PowerUpsCount[0]++;
        }
    }
    public IEnumerator DelayToClose()
    {
        yield return new WaitForSeconds(5);
        PageControl.Instance.StopSimulation();
        gameObject.SetActive(false);
    }

    private void Start()
    {
        if (!GameState.Instance.HasAprimor)
        {
            GameState.Instance.HasAprimor = true;
            GameState.Instance.StartMascote(GameState.Instance.aprimoramento);
            GameState.Instance.Save();
        }
    }
}
