using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GplayConfig : MonoBehaviour
{
    public GameObject[] ViewBar;
    public int Pageindex = 1;
    public string User;
    public string Pass;
    public bool IsLogin;
    public static GplayConfig Instance;
    public GameObject[] Set;
    public App app;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        foreach (App _app in FindObjectsOfType<App>())
        {
            if (_app.Name == "Google Play")
            {
                app = _app;
            }
        }
    }
    private void Update()
    {
        if (!PageControl.Instance.CanUseInternet(0, app))
        {
            Pageindex = 4;
            for (int i = 0; i < ViewBar.Length; i++)
            {
                ViewBar[i].SetActive(i == Pageindex);
            }
            return;
        }
        if (IsLogin) Pageindex = 0;
        for (int i = 0; i < ViewBar.Length; i++)
        {
            ViewBar[i].SetActive(i == Pageindex);
        }
        Set[0].SetActive(Pageindex == 3);
        Set[1].SetActive(Pageindex != 3);
    }

    public void Return()
    {
        switch(Pageindex)
        {
            case 0:
                PageControl.Instance.MacroIndex = 0;
                break;
            case 1:
                PageControl.Instance.MacroIndex = 0;
                break;
            case 2:
                PageControl.Instance.MacroIndex = 0;
                break;
            case 3:
                Pageindex = 1;
                break;
            case 4:
                PageControl.Instance.MacroIndex = 0;
                break;
        }
    }

    public void EnterSubmenu(int i)
    {
        Pageindex = i;
    } 
}
