using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChromeMaster : MonoBehaviour
{
    public List<string> History = new List<string>();
    public TMPro.TMP_InputField site;
    public TMPro.TMP_InputField pesquisa;
    public GameObject[] Children;
    public List<string> Allowed = new List<string>();
    public static ChromeMaster Instance;
    public App localInst;
    public bool[] SitesActivated;


    private void Awake()
    {
        Instance = this;
        SitesActivated = new bool[Children.Length];
    }

    public void Home()
    {
        string localCheck;
        localCheck = "https://www.google.com.br";
        History.Add(localCheck);
        if (PageControl.Instance.CanUseInternet(500, localInst))
        {
            if (Allowed.Contains(localCheck))
            {
                for (int i = 0; i < Children.Length; i++)
                {
                    int ala = Allowed.IndexOf(localCheck);
                    Children[i].SetActive(i == ala);
                    SitesActivated[i] = i == ala;
                }
            }
            else
            {
                for (int i = 0; i < Children.Length; i++)
                {
                    Children[i].SetActive(i == 1);
                    SitesActivated[i] = i == 1;
                }
            }
        }
        else
        {
            for (int i = 0; i < Children.Length; i++)
            {
                Children[i].SetActive(i == 0);
                SitesActivated[i] = i == 0;
            }
        }
        UpdateWebsite();
    }
    public void EnterSite()
    {
        string localCheck;
        localCheck = site.text;
        if (PageControl.Instance.CanUseInternet(500, localInst))
        {
            if (Allowed.Contains(localCheck))
            {
                if (PageControl.Instance.CanUseInternet(500, localInst))
                {
                    if (Allowed.Contains(localCheck))
                    {
                        for (int i = 0; i < Children.Length; i++)
                        {
                            int ala = Allowed.IndexOf(localCheck);
                            Children[i].SetActive(i == ala);
                            SitesActivated[i] = i == ala;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Children.Length; i++)
                        {
                            Children[i].SetActive(i == 1);
                            SitesActivated[i] = i == 1;
                        }
                    }
                }
            }
            else
            {
                if (localCheck.Contains("google.com"))
                {
                    if (!localCheck.Contains("www."))
                    {
                        localCheck = "www." + localCheck;
                    }
                    if (!localCheck.Contains("https://"))
                    {
                        localCheck = "https://" + localCheck;
                    }
                    if (!localCheck.Contains(".br"))
                    {
                        localCheck = localCheck + ".br";
                    }
                }
                else
                {
                    localCheck = "https://www.google.com.br?search=";
                    string[] locallocal;
                    string lul = site.text;
                    locallocal = lul.Split(char.Parse(" "));
                    for (int i = 0; i < locallocal.Length; i++)
                    {
                        if (i != 0) localCheck = localCheck + "+";
                        localCheck = localCheck + locallocal[i];
                    }
                }
                if (PageControl.Instance.CanUseInternet(500, localInst))
                {
                    if (Allowed.Contains(localCheck))
                    {
                        for (int i = 0; i < Children.Length; i++)
                        {
                            int ala = Allowed.IndexOf(localCheck);
                            Children[i].SetActive(i == ala);
                            SitesActivated[i] = i == ala;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Children.Length; i++)
                        {
                            Children[i].SetActive(i == 1);
                            SitesActivated[i] = i == 1;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Children.Length; i++)
                    {
                        Children[i].SetActive(i == 0);
                        SitesActivated[i] = i == 0;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < Children.Length; i++)
            {
                Children[i].SetActive(i == 0);
                SitesActivated[i] = i == 0;
            }
        }
        History.Add(localCheck);
        UpdateWebsite();
    }
    public void Return()
    {
        if (History.Count > 1)
        {
            History.RemoveAt(History.Count - 1);
            string localCheck;
            localCheck = History[History.Count - 1];
            if (PageControl.Instance.CanUseInternet(500, localInst))
            {
                if (Allowed.Contains(localCheck))
                {
                    for (int i = 0; i < Children.Length; i++)
                    {
                        int ala = Allowed.IndexOf(localCheck);
                        Children[i].SetActive(i == ala);
                        SitesActivated[i] = i == ala;
                    }
                }
                else
                {
                    for (int i = 0; i < Children.Length; i++)
                    {
                        Children[i].SetActive(i == 1);
                        SitesActivated[i] = i == 1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < Children.Length; i++)
                {
                    Children[i].SetActive(i == 0);
                    SitesActivated[i] = i == 0;
                }
            }
        }
        else
        {
            PageControl.Instance.MacroIndex = 0;
        }
        UpdateWebsite();
    }
    public void Pesquisar()
    {
        string localCheck;
        string[] locallocal;
        string lul = pesquisa.text.ToLower();
        locallocal = lul.Split(char.Parse(" "));
        localCheck = History[History.Count - 1];
        localCheck = localCheck + "?search=";
        if (locallocal.Length <= 0)
        {
            UpdateWebsite();
            return;
        }
        for (int i = 0; i < locallocal.Length; i++)
        {
            if (i != 0) localCheck = localCheck + "+";
            localCheck = localCheck + locallocal[i];
        }
        History.Add(localCheck);
        if (PageControl.Instance.CanUseInternet(500, localInst))
        {
            if (Allowed.Contains(localCheck))
            {
                for (int i = 0; i < Children.Length; i++)
                {
                    int ala = Allowed.IndexOf(localCheck);
                    Children[i].SetActive(i == ala);
                    SitesActivated[i] = i == ala;
                }
            }
            else
            {
                for (int i = 0; i < Children.Length; i++)
                {
                    Children[i].SetActive(i == 1);
                    SitesActivated[i] = i == 1;
                }
            }
        }
        else
        {
            for (int i = 0; i < Children.Length; i++)
            {
                Children[i].SetActive(i == 0);
                SitesActivated[i] = i == 0;
            }
        }
        UpdateWebsite();
    }
    public void UpdateWebsite()
    {
        site.text = History[History.Count - 1];
        pesquisa.text = "";
    }
}
