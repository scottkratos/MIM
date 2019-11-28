using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GplayStoreInfo : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Titulo;
    public Image Thumbnail;
    public NewerFakeApp InstallingApp;
    [SerializeField]
    private TMPro.TextMeshProUGUI but;
    public static GplayStoreInfo Instance;
    private bool IsInstalled;

    private void Awake()
    {
        Instance = this;
    }
    public void UpdateInfo(string tit, Sprite img, NewerFakeApp _app)
    {
        Titulo.text = tit;
        Thumbnail.sprite = img;
        InstallingApp = _app;
        DetectInSystem();
    }

    private void DetectInSystem()
    {
        foreach (AppLocation aploc in PageControl.Instance.apps)
        {
            if (InstallingApp != null)
            {
                if (aploc.App.Type == InstallingApp.Type)
                {
                    but.text = "Desinstalar";
                    IsInstalled = true;
                    break;
                }
                else
                {
                    but.text = "Instalar";
                    IsInstalled = false;
                }
            }
            else
            {
                but.text = "Instalar";
                IsInstalled = false;
            }
        }
    }

    private void Update()
    {
        DetectInSystem();
    }
    public void Select()
    {
        if (IsInstalled)
        {
            PageControl.Instance.UninstallApp(InstallingApp.Type);
        }
        else
        {
            PageControl.Instance.InstallApp(InstallingApp);
        }
    }
}
