using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageControl : MonoBehaviour
{
    [Header("Configuracoes:")]
    [Space]
    [Header("Minigame:")]
    public float Timer;
    public bool[] Objectives;
    private bool[] ConfObjectives;
    public MascoteFalas[] Falas;
    public MascoteFalas[] FailFalas;
    public GameState.Minigames minigame;
    public bool IsActive;
    [Space]
    [Header("Home:")]
    public bool IsBlocked;
    public int MacroIndex;
    public int MicroIndex;
    [Range(1, 7, order = 1)]
    public int Pages;
    [Range(1, 7, order = 1)]
    public int CurrentPage;
    public List<AppLocation> apps;
    public List<AppLocation> homeapps;
    public int BackgroundIndex;
    [Space]
    [Header("Opcoes Rapidas:")]
    public bool IsWifiEnabled;
    public bool IsGPSEnabled;
    public bool IsBluetoothEnabled;
    public bool IsDadosEnabled;
    public bool IsEnergyEnabled;
    public bool IsPlaneModeEnabled;
    public bool IsLightEnabled;
    [Range(80, 0)]
    public float lightLevel;
    [Space]
    [Header("Configurações:")]
    public RedeWifi[] RedesDisponiveis;
    public int RedeConectada;
    public float ArmazenamentoMaximo;
    public float DadosMaximos;
    public bool USBTheth;
    public bool BluetoothTeth;
    public bool AllowVPN;
    public PontoDeAcessoWifi PontoDeAcesso;
    public string BluetoothName;
    public DispositivosBluetooth[] DisBluetooth;
    public List<FakeArch> Arquivos = new List<FakeArch>();
    public List<FakeTransfer> ArquivosTransmitidos = new List<FakeTransfer>();
    public bool IsNotifyEnabled;
    [Space]
    [Header("Contatos Wpp:")]
    public WhatsAppControl[] Contatos;
    [Space]
    [Header("Config GooglePlay:")]
    public bool IsLogin;
    public string User;
    public string Pass;
    [Space]
    [Header("Constantes:")]
    public float DadosUsados;
    public float RedeUsada;
    public float ArmazenamentoTotalOcupado;
    public float ArmazenamentoFotoseVideo;
    public float ArmazenamentoMusicaeAudio;
    public float ArmazenamentoJogos;
    public float ArmazenamentoFilmesTV;
    public float ArmazenamentoOutros;
    public float Bateria;
    public Sprite[] backgrounds;
    public Image Background;
    public GameObject[] BlockHome;
    public GameObject AppPrefab;
    public GameObject FailPrefab;
    public Slider slider;
    public List<Pelicula> NumInsts = new List<Pelicula>();
    public List<App> AllApps = new List<App>();
    public Line line;
    public int IsGaveta = 1;
    public int IsOpcoesRapidas = 1;
    public MacroLevel parent;
    public GameObject NotificarionSquad;
    public GameObject NotificationPrefab;
    public GameObject[] OpennableApps;
    public List<int> OpennedApps = new List<int>();
    public GameObject[] ActivateApps;
    public GameObject[] InactivateApps;
    public static PageControl Instance;
    private UsoDeDadosAdvanced usodados;
    [Space]
    [Header("Android e essas pohas:")]
    private AndroidJavaObject camera1;


    private void Awake()
    {
        Instance = this;
    }

    private void LightControl()
    {
        AndroidJavaClass cameraClass = new AndroidJavaClass("android.hardware.Camera");
        WebCamDevice[] devices = WebCamTexture.devices;
        int camID = 0;
        camera1 = cameraClass.CallStatic<AndroidJavaObject>("open", camID);
        if (IsLightEnabled)
        {
            if (camera1 != null)
            {
                AndroidJavaObject cameraParameters = camera1.Call<AndroidJavaObject>("getParameters");
                cameraParameters.Call("setFlashMode", "torch");
                camera1.Call("setParameters", cameraParameters);
                camera1.Call("startPreview");
            }
        }
        else
        {
            if (camera1 != null)
            {
                camera1.Call("stopPreview");
            camera1.Call("release");
            }
        }
    }
    private void Update()
    {
        Background.sprite = backgrounds[BackgroundIndex];
        CheckObjectives();
        TrackOpenApps();
        if (IsBlocked)
        {
            BlockHome[0].SetActive(true);
            BlockHome[1].SetActive(false);
        }
        else
        {
            BlockHome[1].SetActive(true);
            BlockHome[0].SetActive(false);
        }
        if (IsPlaneModeEnabled)
        {
            IsWifiEnabled = false;
            IsDadosEnabled = false;
        }
        if (!IsWifiEnabled)
        {
            RedeConectada = -1;
        }
        AjustBrightness();
        if (!IsActive) return;
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Failed();
            Timer = 0;
        }
    }
    public void Failed()
    {
        AudioManager.Instance.StartPlaying(1);
        IsActive = false;
        FailPrefab.SetActive(true);
    }

    public void Restart()
    {
        FailPrefab.SetActive(false);
        parent.StartGame();
    }

    public void Activate()
    {
        AudioManager.Instance.PlayMusic(1);
        GplayConfig.Instance.Pass = Pass;
        GplayConfig.Instance.User = User;
        GplayConfig.Instance.IsLogin = IsLogin;
        for (int i = 0; i < DisBluetooth.Length; i++)
        {
            DisBluetooth[i].Status = false;
        }
        if (GameState.Instance.PowerUpsActive[2]) RedesDisponiveis[2].Senha = "";
        else RedesDisponiveis[2].Senha = "panelavelha";
        for (int i = 0; i < ActivateApps.Length; i++)
        {
            ActivateApps[i].SetActive(true);
        }
        for (int i = 0; i < InactivateApps.Length; i++)
        {
            InactivateApps[i].SetActive(false);
        }
        if (usodados == null)
        {
            usodados = FindObjectOfType<UsoDeDadosAdvanced>();
        }
        //usodados.ClearApp();
        for (int i = 0; i < apps.Count; i++)
        {
            usodados.AddApp(apps[i].App);
        }
        for (int i = 0; i < homeapps.Count; i++)
        {
            usodados.AddApp(homeapps[i].App);
        }
        Bateria = Timer;
        CreateObjectives();
        RedeUsada = 0;
        DadosUsados = 0;
        if (MacroIndex != 0)
        {
            if (OpennableApps[MacroIndex].GetComponent<ConfigMaster>() != null)
            {
                ConfigMaster.PageIndex = MicroIndex;
            }
        }
        for (int i = 0; i < NumInsts.Count; i++)
        {
            NumInsts[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < Pages; i++)
        {
            NumInsts[i].gameObject.SetActive(true);
        }
        AdaptPages();
    }

    public void AjustBrightness()
    {
        lightLevel = Mathf.Abs(slider.value);
    }

    public void OpcoesUpdate(string input)
    {
        AudioManager.Instance.PlaySFX(0);
        switch (input)
        {
            case "Wifi":
                IsWifiEnabled = !IsWifiEnabled;
                break;
            case "GPS":
                IsGPSEnabled = !IsGPSEnabled;
                break;
            case "Bluetooth":
                IsBluetoothEnabled = !IsBluetoothEnabled;
                break;
            case "Dados":
                IsDadosEnabled = !IsDadosEnabled;
                break;
            case "Energy":
                IsEnergyEnabled = !IsEnergyEnabled;
                break;
            case "Plane":
                IsPlaneModeEnabled = !IsPlaneModeEnabled;
                break;
            case "Light":
                IsLightEnabled = !IsLightEnabled;
                LightControl();
                break;
        }
    }

    public void AjustApps()
    {
        foreach (App _app in FindObjectsOfType<App>())
        {
            Destroy(_app.gameObject);
        }
        for (int i = 0; i < AllApps.Count; i++)
        {
            AllApps.RemoveAt(0);
        }
        foreach (App _app in FindObjectsOfType<App>())
        {
            AllApps.Add(_app);
        }
        for (int i = 0; i < homeapps.Count; i++)
        {
            GameObject Inst;
            Inst = Instantiate(AppPrefab, line.slots[homeapps[i].Slot].transform);
            App app = Inst.GetComponent<App>();
            switch (GameState.Instance.CT)
            {
                case GameState.CelType.Google:
                    app.Image = homeapps[i].CApp.app.sprites[0];
                    break;
                case GameState.CelType.Samsung:
                    app.Image = homeapps[i].CApp.app.sprites[1];
                    break;
                case GameState.CelType.LG:
                    app.Image = homeapps[i].CApp.app.sprites[2];
                    break;
                default:
                    app.Image = homeapps[i].CApp.app.sprites[0];
                    break;
            }
            app.Name = homeapps[i].CApp.app.Nome;
            app.Type = homeapps[i].CApp.app.Type;
            app.DadosMoveisUsados = homeapps[i].CApp.app.DadosMoveisUsados;
            app.DadosPerSec = homeapps[i].CApp.app.DadosPerSec;
            app.RedeUsada = homeapps[i].CApp.app.RedeUsada;
            app.Size = homeapps[i].CApp.app.Size;
            app.dataType = homeapps[i].CApp.app.DataType;
            homeapps[i].App = app;
            switch (homeapps[i].CApp.app.DataType)
            {
                case App.DataType.FotoseVideo:
                    ArmazenamentoFotoseVideo += homeapps[i].CApp.app.Size;
                    break;
                case App.DataType.MusicaeAudio:
                    ArmazenamentoMusicaeAudio += homeapps[i].CApp.app.Size;
                    break;
                case App.DataType.Jogos:
                    ArmazenamentoJogos += homeapps[i].CApp.app.Size;
                    break;
                case App.DataType.FilmesTV:
                    ArmazenamentoFilmesTV += homeapps[i].CApp.app.Size;
                    break;
                case App.DataType.Outros:
                    ArmazenamentoOutros += homeapps[i].CApp.app.Size;
                    break;
            }
        }
        for (int i = 0; i < apps.Count; i++)
        {
            GameObject Inst;
            Inst = Instantiate(AppPrefab, NumInsts[apps[i].Pelicula].lines[apps[i].Line].slots[apps[i].Slot].transform);
            App app = Inst.GetComponent<App>();
            switch (GameState.Instance.CT)
            {
                case GameState.CelType.Google:
                    app.Image = apps[i].CApp.app.sprites[0];
                    break;
                case GameState.CelType.Samsung:
                    app.Image = apps[i].CApp.app.sprites[1];
                    break;
                case GameState.CelType.LG:
                    app.Image = apps[i].CApp.app.sprites[2];
                    break;
                default:
                    app.Image = apps[i].CApp.app.sprites[0];
                    break;
            }
            app.Name = apps[i].CApp.app.Nome;
            app.Type = apps[i].CApp.app.Type;
            app.DadosMoveisUsados = apps[i].CApp.app.DadosMoveisUsados;
            app.DadosPerSec = apps[i].CApp.app.DadosPerSec;
            app.RedeUsada = apps[i].CApp.app.RedeUsada;
            app.Size = apps[i].CApp.app.Size;
            app.dataType = apps[i].CApp.app.DataType;
            apps[i].App = app;
            switch (apps[i].CApp.app.DataType)
            {
                case App.DataType.FotoseVideo:
                    ArmazenamentoFotoseVideo += apps[i].CApp.app.Size;
                    break;
                case App.DataType.MusicaeAudio:
                    ArmazenamentoMusicaeAudio += apps[i].CApp.app.Size;
                    break;
                case App.DataType.Jogos:
                    ArmazenamentoJogos += apps[i].CApp.app.Size;
                    break;
                case App.DataType.FilmesTV:
                    ArmazenamentoFilmesTV += apps[i].CApp.app.Size;
                    break;
                case App.DataType.Outros:
                    ArmazenamentoOutros += apps[i].CApp.app.Size;
                    break;
            }
        }
        for (int i = 0; i < ArquivosTransmitidos.Count; i++)
        {
            switch (ArquivosTransmitidos[i].Data)
            {
                case App.DataType.FotoseVideo:
                    ArmazenamentoFotoseVideo += ArquivosTransmitidos[i].Peso;
                    break;
                case App.DataType.MusicaeAudio:
                    ArmazenamentoMusicaeAudio += ArquivosTransmitidos[i].Peso;
                    break;
                case App.DataType.Jogos:
                    ArmazenamentoJogos += ArquivosTransmitidos[i].Peso;
                    break;
                case App.DataType.FilmesTV:
                    ArmazenamentoFilmesTV += ArquivosTransmitidos[i].Peso;
                    break;
                case App.DataType.Outros:
                    ArmazenamentoOutros += ArquivosTransmitidos[i].Peso;
                    break;
            }
        }
        for (int i = 0; i < Arquivos.Count; i++)
        {
            switch (Arquivos[i].Data)
            {
                case App.DataType.FotoseVideo:
                    ArmazenamentoFotoseVideo += Arquivos[i].Peso;
                    break;
                case App.DataType.MusicaeAudio:
                    ArmazenamentoMusicaeAudio += Arquivos[i].Peso;
                    break;
                case App.DataType.Jogos:
                    ArmazenamentoJogos += Arquivos[i].Peso;
                    break;
                case App.DataType.FilmesTV:
                    ArmazenamentoFilmesTV += Arquivos[i].Peso;
                    break;
                case App.DataType.Outros:
                    ArmazenamentoOutros += Arquivos[i].Peso;
                    break;
            }
        }
        ArmazenamentoTotalOcupado = ArmazenamentoTotalOcupado + ArmazenamentoFotoseVideo + ArmazenamentoMusicaeAudio + ArmazenamentoJogos + ArmazenamentoFilmesTV + ArmazenamentoOutros;
        ArquivosRecebidosManager.Instance.Show();
        Gaveta.Instance.UpdateApps();
        foreach (GavetaPelicula gp in FindObjectsOfType<GavetaPelicula>())
        {
            gp.Drop();
        }
        foreach (OpcoesRapidasPelicula gp in FindObjectsOfType<OpcoesRapidasPelicula>())
        {
            gp.Drop();
        }
        WifiManager.Instance.CreateRows();
        foreach (ArmazenamentoDisplayManager adm in ArmazenamentoDisplayManager.Instances)
        {
            adm.Spawn();
        }
        TransmitirManager.Instance.Spawn();
        InformacoesDoAppManager.Instance.Spawn();
        MessagesManager.Instance.AddLists();
    }

    public void CreateObjectives()
    {
        switch(minigame)
        {
            case GameState.Minigames.Chrome:
                Objectives = new bool[4];
                ConfObjectives = new bool[4];
                break;
            case GameState.Minigames.WhatsApp:
                Objectives = new bool[2];
                ConfObjectives = new bool[2];
                break;
            case GameState.Minigames.IntroWifi:
                Objectives = new bool[7];
                ConfObjectives = new bool[7];
                break;
            case GameState.Minigames.WifiFacil:
                Objectives = new bool[1];
                ConfObjectives = new bool[1];
                break;
            case GameState.Minigames.WifiMedio:
                Objectives = new bool[4];
                ConfObjectives = new bool[4];
                break;
            case GameState.Minigames.WifiDificil:
                Objectives = new bool[1];
                ConfObjectives = new bool[1];
                break;
            case GameState.Minigames.IntroDadosMoveis:
                Objectives = new bool[8];
                ConfObjectives = new bool[8];
                break;
            case GameState.Minigames.DadosMoveisFacil:
                Objectives = new bool[2];
                ConfObjectives = new bool[2];
                break;
            case GameState.Minigames.DadosMoveisMedio:
                Objectives = new bool[1];
                ConfObjectives = new bool[1];
                break;
            case GameState.Minigames.DadosMoveisDificil:
                Objectives = new bool[1];
                ConfObjectives = new bool[1];
                break;
            case GameState.Minigames.ModoAviao:
                Objectives = new bool[3];
                ConfObjectives = new bool[3];
                break;
            case GameState.Minigames.Remix1:
                Objectives = new bool[3];
                ConfObjectives = new bool[3];
                break;
            case GameState.Minigames.IntroBluetooth:
                Objectives = new bool[3];
                ConfObjectives = new bool[3];
                break;
            case GameState.Minigames.BluetoothFacil:
                Objectives = new bool[1];
                ConfObjectives = new bool[1];
                break;
            case GameState.Minigames.BluetoothMedio:
                Objectives = new bool[1];
                ConfObjectives = new bool[1];
                break;
            case GameState.Minigames.ArmazenamentoIntro:
                Objectives = new bool[4];
                ConfObjectives = new bool[4];
                break;
            case GameState.Minigames.ContaGoogle:
                Objectives = new bool[2];
                ConfObjectives = new bool[2];
                break;
            case GameState.Minigames.InstallApp:
                Objectives = new bool[2];
                ConfObjectives = new bool[2];
                break;
            case GameState.Minigames.UninstallApp:
                Objectives = new bool[4];
                ConfObjectives = new bool[4];
                break;
            case GameState.Minigames.PurchaseApp:
                Objectives = new bool[2];
                ConfObjectives = new bool[2];
                break;
            case GameState.Minigames.Remix2:
                Objectives = new bool[3];
                ConfObjectives = new bool[3];
                break;
            case GameState.Minigames.Remix3:
                Objectives = new bool[2];
                ConfObjectives = new bool[2];
                break;
            case GameState.Minigames.Remix4:
                Objectives = new bool[2];
                ConfObjectives = new bool[2];
                break;
        }
    }

    public void CheckObjectives()
    {
        if (!IsActive) return;
        switch (minigame)
        {
            case GameState.Minigames.Chrome:
                if (!IsBlocked)
                {
                    Objectives[0] = true;
                    if (Objectives[0])
                    {
                        if (!Objectives[1]) Objectives[1] = CurrentPage == 2;
                        else
                        {
                            if (!Objectives[2]) Objectives[2] = CurrentPage == 1;
                            else
                            {
                                Objectives[3] = MacroIndex == 2;
                            }
                        }
                    }
                }
                break;
            case GameState.Minigames.WhatsApp:
                if (!Objectives[0]) Objectives[0] = MacroIndex == 3;
                else
                {
                    Objectives[1] = MessagesManager.Instance.Contatos[0].RecivedMessages[MessagesManager.Instance.Contatos[0].RecivedMessages.Count - 1].Sender == 0 && MessagesManager.Instance.Contatos[0].RecivedMessages[MessagesManager.Instance.Contatos[0].RecivedMessages.Count - 1].Message.ToLower() == "eu vou";
                }
                break;
            case GameState.Minigames.IntroWifi:
                if (Objectives[4])
                {
                    Objectives[4] = RedeConectada == 0;
                    Objectives[5] = MacroIndex == 0;
                    if (Objectives[5])
                    {
                        if (IsOpcoesRapidas == 2)
                        {
                            Objectives[6] = true;
                        }
                    }
                }
                else
                {
                    Objectives[0] = MacroIndex == 1 && (ConfigMaster.PageIndex == 0 || ConfigMaster.PageIndex == 1 || ConfigMaster.PageIndex == 7 || ConfigMaster.PageIndex == 8);
                    if (Objectives[0])
                    {
                        Objectives[1] = ConfigMaster.PageIndex == 1 || ConfigMaster.PageIndex == 7 || ConfigMaster.PageIndex == 8;
                        if (Objectives[1])
                        {
                            Objectives[2] = IsWifiEnabled;
                            if (Objectives[2])
                            {
                                if (!Objectives[3]) Objectives[3] = ConfigMaster.PageIndex == 7 || ConfigMaster.PageIndex == 8;
                                if (Objectives[3])
                                {
                                    Objectives[4] = RedeConectada == 0;
                                }
                            }
                        }
                    }
                }
                break;
            case GameState.Minigames.WifiFacil:
                Objectives[0] = RedeConectada == 3;
                break;
            case GameState.Minigames.WifiMedio:
                if (!Objectives[0])
                {
                    Objectives[0] = MacroIndex == 2;
                }
                else
                {
                    Objectives[1] = RedeConectada == 6;
                    if (Objectives[1])
                    {
                        Objectives[2] = MacroIndex == 2;
                        if (Objectives[2])
                        {
                            Objectives[3] = ChromeMaster.Instance.Children[4].activeSelf;
                        }
                    }
                }
                break;
            case GameState.Minigames.WifiDificil:
                Objectives[0] = RedeConectada == 4;
                break;
            case GameState.Minigames.IntroDadosMoveis:
                if (Objectives[0])
                {
                    Objectives[1] = ConfigMaster.PageIndex == 1 || ConfigMaster.PageIndex == 9 || ConfigMaster.PageIndex == 10 || ConfigMaster.PageIndex == 12;
                    if (!Objectives[3])
                    {
                        if (Objectives[1])
                        {
                            Objectives[2] = ConfigMaster.PageIndex == 9;
                            if (Objectives[2])
                            {
                                Objectives[3] = IsDadosEnabled;
                            }
                        }
                    }
                    else
                    {
                        if (!Objectives[7])
                        {
                            Objectives[4] = (ConfigMaster.PageIndex == 1 || ConfigMaster.PageIndex == 10 || ConfigMaster.PageIndex == 12);
                            if (Objectives[4])
                            {
                                Objectives[5] = ConfigMaster.PageIndex == 10 || ConfigMaster.PageIndex == 12;
                                if (Objectives[5])
                                {
                                    Objectives[6] = ConfigMaster.PageIndex == 12;
                                    if (Objectives[6])
                                    {
                                        Objectives[7] = MacroIndex == 0;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Objectives[0] = MacroIndex == 1 && (ConfigMaster.PageIndex == 0 || ConfigMaster.PageIndex == 1 || ConfigMaster.PageIndex == 9);
                }
                break;
            case GameState.Minigames.DadosMoveisFacil:
                if (!Objectives[0]) Objectives[0] = MacroIndex == 1 && ConfigMaster.PageIndex == 7;
                else
                {
                    Objectives[1] = IsDadosEnabled;
                }
                break;
            case GameState.Minigames.DadosMoveisMedio:
                Objectives[0] = !IsDadosEnabled;
                break;
            case GameState.Minigames.DadosMoveisDificil:
                Objectives[0] = MessagesManager.Instance.Contatos[0].RecivedMessages[MessagesManager.Instance.Contatos[0].RecivedMessages.Count - 1].Sender == 0 && MessagesManager.Instance.Contatos[0].RecivedMessages[MessagesManager.Instance.Contatos[0].RecivedMessages.Count - 1].Message == "sim";
                break;
            case GameState.Minigames.ModoAviao:
                Objectives[0] = MacroIndex == 1;
                if (Objectives[0])
                {
                    Objectives[1] = ConfigMaster.PageIndex == 1;
                    if (Objectives[1])
                    {
                        Objectives[2] = IsPlaneModeEnabled;
                    }
                }
                break;
            case GameState.Minigames.Remix1:
                Objectives[0] = RedeConectada == 5;
                if (Objectives[0])
                {
                    Objectives[1] = MessagesManager.Instance.Contatos[4].RecivedMessages[MessagesManager.Instance.Contatos[4].RecivedMessages.Count - 1].Sender == 0 && MessagesManager.Instance.Contatos[4].RecivedMessages[MessagesManager.Instance.Contatos[4].RecivedMessages.Count - 1].Message.ToLower() == "ja ta com meu dinheiro?";
                    if (Objectives[1])
                    {
                        Objectives[2] = ChromeMaster.Instance.Children[4].activeSelf;
                    }
                }
                break;
            case GameState.Minigames.IntroBluetooth:
                Objectives[0] = MacroIndex == 1;
                if (Objectives[0])
                {
                    Objectives[1] = ConfigMaster.PageIndex == 2 || ConfigMaster.PageIndex == 18;
                    if (Objectives[1])
                    {
                        Objectives[2] = ConfigMaster.PageIndex == 18;
                    }
                }
                break;
            case GameState.Minigames.BluetoothFacil:
                Objectives[0] = DisBluetooth[3].Status;
                break;
            case GameState.Minigames.BluetoothMedio:
                Objectives[0] = DisBluetooth[3].Status;
                break;
            case GameState.Minigames.ArmazenamentoIntro:
                Objectives[0] = MacroIndex == 1;
                if (Objectives[0])
                {
                    Objectives[1] = ConfigMaster.PageIndex == 6 || ConfigMaster.PageIndex == 32;
                    if (Objectives[1])
                    {
                        Objectives[2] = ConfigMaster.PageIndex == 32;
                        if (Objectives[2])
                        {
                            bool Check = true;
                            foreach (FakeArch ak in Arquivos)
                            {
                                if (ak.Nome == "APS.pdf") Check = false;
                            }
                            Objectives[3] = Check;
                        }
                    }
                }
                break;
            case GameState.Minigames.ContaGoogle:
                Objectives[0] = MacroIndex == 4;
                if (Objectives[0])
                {
                    Objectives[1] = !GplayConfig.Instance.IsLogin;
                }
                break;
            case GameState.Minigames.InstallApp:
                bool check = false;
                foreach (AppLocation aploc in apps)
                {
                    if (aploc.App.Name == "My Boy") check = true;
                }
                Objectives[0] = check;
                if (Objectives[0])
                {
                    Objectives[1] = DisBluetooth[4].Status;
                }
                break;
            case GameState.Minigames.UninstallApp:
                Objectives[0] = MacroIndex == 1;
                if (Objectives[0])
                {
                    Objectives[1] = ConfigMaster.PageIndex == 6 || ConfigMaster.PageIndex == 32;
                    if (Objectives[1])
                    {
                        Objectives[2] = ConfigMaster.PageIndex == 32;
                        if (Objectives[2])
                        {
                            bool checking = true;
                            foreach (App aploc in FindObjectsOfType<App>())
                            {
                                if (aploc.Type == App.AppType.tinder) checking = false;
                            }
                            Objectives[3] = checking;
                        }
                    }
                }

                break;
            case GameState.Minigames.PurchaseApp:
                Objectives[0] = MacroIndex == 4;
                if (Objectives[0])
                {
                    bool newercheck = false;
                    foreach (AppLocation aploc in apps)
                    {
                        if (aploc.App.Name == "Empatia") newercheck = true;
                    }
                    Objectives[1] = newercheck;
                }
                break;
            case GameState.Minigames.Remix2:
                Objectives[0] = IsDadosEnabled;
                if (Objectives[0])
                {
                    Objectives[1] = MessagesManager.Instance.Contatos[1].RecivedMessages[MessagesManager.Instance.Contatos[1].RecivedMessages.Count - 1].Sender == 0 && (MessagesManager.Instance.Contatos[1].RecivedMessages[MessagesManager.Instance.Contatos[1].RecivedMessages.Count - 1].Message == "cheguei" || MessagesManager.Instance.Contatos[1].RecivedMessages[MessagesManager.Instance.Contatos[1].RecivedMessages.Count - 1].Message == "cheguei!");
                    if (Objectives[1])
                    {
                        Objectives[2] = RedeConectada == 1;
                    }
                }
                break;
            case GameState.Minigames.Remix3:
                Objectives[0] = ChromeMaster.Instance.Children[4].activeSelf;
                if (Objectives[0])
                {
                    Objectives[1] = DisBluetooth[3].Status;
                }
                break;
            case GameState.Minigames.Remix4:
                bool lastcheck = true;
                foreach (AppLocation aploc in apps)
                {
                    if (aploc.App.Name == "Empatia" || aploc.App.Name == "Pou") lastcheck = false;
                }
                Objectives[0] = lastcheck;
                if (Objectives[0])
                {
                    bool lastlastcheck = false;
                    foreach (AppLocation aploc in apps)
                    {
                        if (aploc.App.Type == App.AppType.Pokemon) lastlastcheck = true;
                    }
                    Objectives[1] = lastlastcheck;
                }
                break;
        }
        CompleteObjective();
    }

    public void InstallApp(NewerFakeApp _app)
    {
        for (int _page = 0; _page < 7; _page++)
        {
            for (int _line = 0; _line < 4; _line++)
            {
                for (int _slot = 0; _slot < 5; _slot ++)
                {
                    if (!NumInsts[_page].transform.GetChild(_line).transform.GetChild(_slot).GetComponent<Slot>().IsFilled)
                    {
                        while (_page > Pages)
                        {
                            CreatePage();
                        }
                        AppLocation inst = new AppLocation();
                        inst.Line = _line;
                        inst.Pelicula = _page;
                        inst.Slot = _slot;
                        GameObject Inst;
                        Inst = Instantiate(AppPrefab, NumInsts[_page].lines[_line].slots[_slot].transform);
                        App app = Inst.GetComponent<App>();
                        app.Name = _app.Name;
                        app.Image = _app.Image;
                        app.RedeUsada = _app.RedeUsada;
                        app.Size = _app.Size;
                        app.Type = _app.Type;
                        app.dataType = _app.dataType;
                        app.DadosPerSec = _app.DadosPerSec;
                        app.DadosMoveisUsados = _app.DadosMoveisUsados;
                        inst.App = app;
                        FakeCreateApp fca = new FakeCreateApp();
                        AppConfig apconf = new AppConfig();
                        apconf.DadosMoveisUsados = _app.DadosMoveisUsados;
                        apconf.DadosPerSec = _app.DadosPerSec;
                        apconf.DataType = _app.dataType;
                        apconf.Nome = _app.Name;
                        apconf.Size = _app.Size;
                        apconf.RedeUsada = _app.RedeUsada;
                        apconf.sprites = new Sprite[] { _app.Image, _app.Image, _app.Image };
                        apconf.Type = _app.Type;
                        fca.app = apconf;
                        inst.CApp = fca;
                        apps.Add(inst);
                        foreach (UsoDeDadosAdvanced go in FindObjectsOfType<UsoDeDadosAdvanced>())
                        {
                            go.AddApp(app);
                        }
                        AjustApps();
                        return;
                    }
                }
            }
        }
    }

    public void UninstallApp(App.AppType tipo)
    {
        AppLocation lcal = null;
        for (int i = 0; i < homeapps.Count; i++)
        {
            if (homeapps[i].App.Type == tipo)
            {
                lcal = homeapps[i];
                homeapps.RemoveAt(i);
                foreach (UsoDeDadosAdvanced go in FindObjectsOfType<UsoDeDadosAdvanced>())
                {
                    go.RemoveApp(tipo);
                }
                break;
            }
        }
        for (int i = 0; i < apps.Count; i++)
        {
            if (apps[i].App.Type == tipo)
            {
                lcal = apps[i];
                apps.RemoveAt(i);
                foreach (UsoDeDadosAdvanced go in FindObjectsOfType<UsoDeDadosAdvanced>())
                {
                    go.RemoveApp(tipo);
                }
                break;
            }
        }
        foreach(App _appu in FindObjectsOfType<App>())
        {
            if (_appu.Name == lcal.App.Name)
            {
                Destroy(_appu.gameObject);
            }
        }
        AjustApps();
    }

    public void OpenApp(int value)
    {
        AudioManager.Instance.PlaySFX(0);
        if (!OpennedApps.Contains(value)) OpennedApps.Add(value);
        MacroIndex = value;
    }
    public void Return()
    {
        AudioManager.Instance.PlaySFX(0);
        switch (MacroIndex)
        {
            case 0:
                MacroIndex = 0;
                break;
            case 1:
                switch (ConfigMaster.PageIndex)
                {
                    case 0:
                        MacroIndex = 0;
                        break;
                    case 1:
                        ConfigMaster.PageIndex = 0;
                        break;
                    case 2:
                        ConfigMaster.PageIndex = 0;
                        break;
                    case 3:
                        ConfigMaster.PageIndex = 0;
                        break;
                    case 4:
                        ConfigMaster.PageIndex = 0;
                        break;
                    case 5:
                        ConfigMaster.PageIndex = 0;
                        break;
                    case 6:
                        ConfigMaster.PageIndex = 0;
                        break;
                    case 7:
                        ConfigMaster.PageIndex = 1;
                        break;
                    case 8:
                        ConfigMaster.PageIndex = 7;
                        break;
                    case 9:
                        ConfigMaster.PageIndex = 1;
                        break;
                    case 10:
                        ConfigMaster.PageIndex = 1;
                        break;
                    case 11:
                        ConfigMaster.PageIndex = 10;
                        break;
                    case 12:
                        ConfigMaster.PageIndex = 10;
                        break;
                    case 13:
                        ConfigMaster.PageIndex = 1;
                        break;
                    case 14:
                        ConfigMaster.PageIndex = 13;
                        break;
                    case 15:
                        ConfigMaster.PageIndex = 1;
                        break;
                    case 16:
                        ConfigMaster.PageIndex = 15;
                        break;
                    case 17:
                        ConfigMaster.PageIndex = 1;
                        break;
                    case 18:
                        ConfigMaster.PageIndex = 2;
                        break;
                    case 19:
                        ConfigMaster.PageIndex = 2;
                        break;
                    case 20:
                        ConfigMaster.PageIndex = 19;
                        break;
                    case 21:
                        ConfigMaster.PageIndex = 19;
                        break;
                    case 22:
                        ConfigMaster.PageIndex = 19;
                        break;
                    case 23:
                        ConfigMaster.PageIndex = 3;
                        break;
                    case 24:
                        ConfigMaster.PageIndex = 23;
                        break;
                    case 25:
                        ConfigMaster.PageIndex = 3;
                        break;
                    case 26:
                        ConfigMaster.PageIndex = 25;
                        break;
                    case 27:
                        ConfigMaster.PageIndex = 5;
                        break;
                    case 28:
                        ConfigMaster.PageIndex = 6;
                        break;
                    case 29:
                        ConfigMaster.PageIndex = 6;
                        break;
                    case 30:
                        ConfigMaster.PageIndex = 6;
                        break;
                    case 31:
                        ConfigMaster.PageIndex = 6;
                        break;
                    case 32:
                        ConfigMaster.PageIndex = 6;
                        break;
                }
                break;
            case 2:
                ChromeMaster.Instance.Return();
                break;
            case 3:
                switch (WhatsConfg.PageIndex)
                {
                    case 0:
                        MacroIndex = 0;
                        break;
                    case 1:
                        WhatsConfg.PageIndex = 0;
                        break;
                    case 2:
                        WhatsConfg.PageIndex = 0;
                        break;
                    case 3:
                        WhatsConfg.PageIndex = 0;
                        break;
                }
                break;
        }
    }

    public void Home()
    {
        AudioManager.Instance.PlaySFX(0);
        MacroIndex = 0;
    }

    public void SegundoPlano()
    {
        AudioManager.Instance.PlaySFX(0);
    }
    public IEnumerator UseInternet()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            switch (MacroIndex)
            {
                case 1:
                    for (int i = 0; i < apps.Count; i++)
                    {
                        if (apps[i].App.Type == App.AppType.Config)
                        {
                            CanUseInternet(0, apps[i].App);
                            break;
                        }
                    }
                    for (int i = 0; i < homeapps.Count; i++)
                    {
                        if (apps[i].App.Type == App.AppType.Config)
                        {
                            CanUseInternet(0, apps[i].App);
                            break;
                        }
                    }
                    break;
            }
        }
    }
    public void TrackOpenApps()
    {
        switch (MacroIndex)
        {
            case 0:
                for (int i = 0; i < OpennableApps.Length; i++)
                {
                    OpennableApps[i].SetActive(false);
                }
                break;
            case 1:
                for (int i = 0; i < OpennableApps.Length; i++)
                {
                    if (i == 0)
                    {
                        OpennableApps[i].SetActive(true);
                    }
                    else
                    {
                        OpennableApps[i].SetActive(false);
                    }
                }
                break;
            case 2:
                for (int i = 0; i < OpennableApps.Length; i++)
                {
                    if (i == 1)
                    {
                        OpennableApps[i].SetActive(true);
                    }
                    else
                    {
                        OpennableApps[i].SetActive(false);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < OpennableApps.Length; i++)
                {
                    if (i == 2)
                    {
                        OpennableApps[i].SetActive(true);
                    }
                    else
                    {
                        OpennableApps[i].SetActive(false);
                    }
                }
                break;
            case 4:
                for (int i = 0; i < OpennableApps.Length; i++)
                {
                    if (i == 3)
                    {
                        OpennableApps[i].SetActive(true);
                    }
                    else
                    {
                        OpennableApps[i].SetActive(false);
                    }
                }
                break;
        }
    }
    public bool CanUseInternet(float usage, App _app)
    {
        if (RedeConectada != -1)
        {
            RedeUsada += usage;
            _app.RedeUsada += usage;
            return true;
        }
        else
        {
            if (IsDadosEnabled)
            {
                DadosUsados += usage;
                _app.DadosMoveisUsados += usage;
                if (DadosUsados > DadosMaximos)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
    public void SendNotification(string tit, string desc, Sprite icon, App sender)
    {
        if (!CanUseInternet(1, sender)) return;
        GameObject OB = Instantiate(NotificationPrefab, NotificarionSquad.transform);
        Notification Not = OB.GetComponent<Notification>();
        Not.Tit = tit;
        Not.Desc = desc;
        Not.Png = icon;
        Not.UpdateInfo();
    }
    public void Reminder()
    {
        AudioManager.Instance.PlayMusic(1);
        AudioManager.Instance.PlaySFX(0);
        int Index = 0;
        for (int i = 0; i < Objectives.Length; i++)
        {
            if (Objectives[i])
            {
                Index = i + 1;
            }
        }
        if (Falas[Index] != null)
        {
            IsActive = false;
            GameState.Instance.StartMascote(Falas[Index]);
        }
        else
        {
            IsActive = false;
            GameState.Instance.StartMascote(Falas[0]);
        }
    }
    public void CompleteObjective()
    {
        for (int i = 0; i < Objectives.Length; i++)
        {
            if (Objectives[i] != ConfObjectives[i])
            {
                if (Objectives[i])
                {
                    AudioManager.Instance.PlaySFX(3);
                }
                else
                {
                    AudioManager.Instance.PlaySFX(4);
                }
                ConfObjectives[i] = Objectives[i];
                if (Objectives[i])
                {
                    if (Falas[i + 1] != null)
                    {
                        IsActive = false;
                        GameState.Instance.StartMascote(Falas[i + 1]);
                    }
                    else
                    {
                        CheckComplete();
                    }
                }
                else
                {
                    if (FailFalas[i] != null)
                    {
                        IsActive = false;
                        GameState.Instance.StartMascote(FailFalas[i]);
                    }
                }
            }
        }
    }
    public void CheckComplete()
    {
        bool AllComplete = true;
        for (int i = 0; i < Objectives.Length; i++)
        {
            if (!Objectives[i])
            {
                AllComplete = false;
                break;
            }
        }
        if (AllComplete)
        {
            EndSimulation();
        }
        else
        {
            IsActive = true;
        }
    }
    public void EndSimulation()
    {
        AudioManager.Instance.PlayMusic(0);
        IsActive = false;
        if (!parent.level.IsDone && parent.level.ID == 1)
        {
            GameState.Instance.StartMascote(GameState.Instance.intro2);
        }
        if (!parent.level.IsDone && parent.level.ID == 23)
        {
            GameState.Instance.StartMascote(GameState.Instance.fim);
        }
        parent.level.IsDone = true;
        parent.IsDone = true;
        AutoLock.Instance.NextLesson();
        GameState.Instance.Save();
        System.GC.Collect();
        gameObject.SetActive(false);
    }

    public void StopSimulation()
    {
        AudioManager.Instance.PlayMusic(0);
        AudioManager.Instance.PlaySFX(0);
        FailPrefab.SetActive(false);
        gameObject.SetActive(false);
    }

    public bool CreatePage()
    {
        if (Pages >= 7) return false;
        NumInsts[Pages].gameObject.SetActive(true);
        Pages++;
        AdaptPages();
        return true;
    }

    public bool DeletePage()
    {
        if (Pages <= 1) return false;
        NumInsts[Pages - 1].gameObject.SetActive(false);
        Pages--;
        AdaptPages();
        return true;
    }

    public void AdaptPages()
    {
        for (int i = 0; i < Pages; i++)
        {
            NumInsts[i].Drop();
        }
    }
    public void ConnectToWifi(int _rede, string password, bool NeedPass)
    {
        if (NeedPass)
        {
            if (RedesDisponiveis[_rede].Senha == password)
            {
                if (_rede == RedeConectada)
                {
                    RedeConectada = -1;
                }
                else
                {
                    RedeConectada = _rede;
                }
            }
        }
        else
        {
            if (_rede == RedeConectada)
            {
                RedeConectada = -1;
            }
            else
            {
                RedeConectada = _rede;
            }
        }
        if (RedeConectada == 8)
        {
            GameState.Instance.EasterEgg = true;
        }
    }
}

[System.Serializable]
public class AppLocation
{
    [Range(0, 6, order = 1)]
    public int Pelicula;
    [Range(0, 3, order = 1)]
    public int Line;
    [Range(0, 4, order = 1)]
    public int Slot;
    public FakeCreateApp CApp;
    public App App;
}
public class FakeCreateApp
{
    public AppConfig app;
}
[System.Serializable]
public class DispositivosBluetooth
{
    public string Name;
    public string Pin;
    public bool Status;
}
[System.Serializable]
public class WhatsAppControl
{
    public string Name;
    public string Desc;
    public Sprite Thumbnail;
    public List<MessageControl> RecivedMessages = new List<MessageControl>();
}
[System.Serializable]
public class MessageControl
{
    public int Sender;
    public string Message;
}