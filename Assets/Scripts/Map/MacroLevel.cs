using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacroLevel : MonoBehaviour
{
    [Header("Configurações:")]
    public int ID;
    public MascoteFalas[] Falas;
    public string Titulo;
    public string Desc;
    public CreateMinigame minigame;
    [Header("Constantes:")]
    public bool IsDone;
    private GameObject SimulacaoPrefab;
    public Level level;

    private void Awake()
    {
        level = GetComponentInChildren<Level>();
        level.ID = ID;
        level.IsDone = IsDone;
        level.Titulo = Titulo;
        level.Desc = Desc;
    }

    private void Start()
    {
        foreach (GameObject gabe in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
        {
            if (!gabe.GetComponent<PageControl>()) continue;
            SimulacaoPrefab = gabe;
        }
    }

    private void Update()
    {
        level.IsDone = IsDone;
    }
    public void StartGame()
    {
        AudioManager.Instance.PlaySFX(0);
        SimulacaoPrefab.SetActive(true);
        Falas = minigame.minigame.Falas;
        level.Falas = Falas;
        if (Falas != null)
        {
            GameState.Instance.StartMascote(Falas[0]);
        }
        else
        {
            PageControl.Instance.IsActive = true;
        }
        PageControl.Instance.IsBlocked = minigame.minigame.IsBlocked;
        if (PageControl.Instance.IsBlocked) Block.Instance.page = 1;
        else Block.Instance.page = 2;
        Block.Instance.Drop();
        PageControl.Instance.homeapps.Clear();
        PageControl.Instance.apps.Clear();
        for (int i = 0; i < minigame.minigame.apps.Count; i++)
        {
            AppLocation _app = new AppLocation();
            _app.Pelicula = minigame.minigame.apps[i].Pelicula;
            _app.Slot = minigame.minigame.apps[i].Slot;
            _app.Line = minigame.minigame.apps[i].Line;
            FakeCreateApp _capp = new FakeCreateApp();
            AppConfig aconf = new AppConfig();
            aconf.DadosMoveisUsados = minigame.minigame.apps[i].CApp.app.DadosMoveisUsados;
            aconf.DadosPerSec = minigame.minigame.apps[i].CApp.app.DadosPerSec;
            aconf.DataType = minigame.minigame.apps[i].CApp.app.DataType;
            aconf.Nome = minigame.minigame.apps[i].CApp.app.Nome;
            aconf.RedeUsada = minigame.minigame.apps[i].CApp.app.RedeUsada;
            aconf.Size = minigame.minigame.apps[i].CApp.app.Size;
            aconf.sprites = minigame.minigame.apps[i].CApp.app.sprites;
            aconf.Type = minigame.minigame.apps[i].CApp.app.Type;
            _capp.app = aconf;
            _app.CApp = _capp;
            PageControl.Instance.apps.Add(_app);
        }
        for (int i = 0; i < minigame.minigame.homeapps.Count; i++)
        {
            AppLocation _app = new AppLocation();
            _app.Pelicula = minigame.minigame.homeapps[i].Pelicula;
            _app.Slot = minigame.minigame.homeapps[i].Slot;
            _app.Line = minigame.minigame.homeapps[i].Line;
            FakeCreateApp _capp = new FakeCreateApp();
            AppConfig aconf = new AppConfig();
            aconf.DadosMoveisUsados = minigame.minigame.homeapps[i].CApp.app.DadosMoveisUsados;
            aconf.DadosPerSec = minigame.minigame.homeapps[i].CApp.app.DadosPerSec;
            aconf.DataType = minigame.minigame.homeapps[i].CApp.app.DataType;
            aconf.Nome = minigame.minigame.homeapps[i].CApp.app.Nome;
            aconf.RedeUsada = minigame.minigame.homeapps[i].CApp.app.RedeUsada;
            aconf.Size = minigame.minigame.homeapps[i].CApp.app.Size;
            aconf.sprites = minigame.minigame.homeapps[i].CApp.app.sprites;
            aconf.Type = minigame.minigame.homeapps[i].CApp.app.Type;
            _capp.app = aconf;
            _app.CApp = _capp;
            PageControl.Instance.homeapps.Add(_app);
        }
        PageControl.Instance.Arquivos.Clear();
        PageControl.Instance.ArquivosTransmitidos.Clear();
        for (int i = 0; i < minigame.minigame.Arquivos.Count; i++)
        {
            FakeArch fa = new FakeArch();
            fa.Data = minigame.minigame.Arquivos[i].Data;
            fa.Nome = minigame.minigame.Arquivos[i].Nome;
            fa.Peso = minigame.minigame.Arquivos[i].Peso;
            fa.Thumbnail = minigame.minigame.Arquivos[i].Thumbnail;
            PageControl.Instance.Arquivos.Add(fa);
        }
        for (int i = 0; i < minigame.minigame.ArquivosTransmitidos.Count; i++)
        {
            FakeTransfer fa = new FakeTransfer();
            fa.Data = minigame.minigame.ArquivosTransmitidos[i].Data;
            fa.Nome = minigame.minigame.ArquivosTransmitidos[i].Nome;
            fa.Peso = minigame.minigame.ArquivosTransmitidos[i].Peso;
            fa.Thumbnail = minigame.minigame.ArquivosTransmitidos[i].Thumbnail;
            fa.ID = minigame.minigame.ArquivosTransmitidos[i].ID;
            PageControl.Instance.ArquivosTransmitidos.Add(fa);
        }
        PageControl.Instance.IsLogin = minigame.minigame.IsLogin;
        PageControl.Instance.User = minigame.minigame.User;
        PageControl.Instance.Pass = minigame.minigame.Pass;
        PageControl.Instance.Contatos = minigame.minigame.Contatos;
        PageControl.Instance.MacroIndex = minigame.minigame.MacroIndex;
        PageControl.Instance.MicroIndex = minigame.minigame.MicroIndex;
        PageControl.Instance.BluetoothName = minigame.minigame.BluetoothName;
        PageControl.Instance.DisBluetooth = minigame.minigame.DisBluetooth;
        PageControl.Instance.IsNotifyEnabled = minigame.minigame.IsNotifyEnabled;
        PageControl.Instance.RedesDisponiveis = minigame.minigame.RedesDisponiveis;
        PageControl.Instance.RedeConectada = minigame.minigame.RedeConectada;
        PageControl.Instance.ArmazenamentoMaximo = minigame.minigame.ArmazenamentoMaximo;
        if (GameState.Instance.PowerUpsActive[1]) PageControl.Instance.DadosMaximos = minigame.minigame.DadosMaximos * 2;
        else PageControl.Instance.DadosMaximos = minigame.minigame.DadosMaximos;
        PageControl.Instance.USBTheth = minigame.minigame.USBTheth;
        PageControl.Instance.BluetoothTeth = minigame.minigame.BluetoothTeth;
        PageControl.Instance.AllowVPN = minigame.minigame.AllowVPN;
        PageControl.Instance.PontoDeAcesso = minigame.minigame.PontoDeAcesso;
        PageControl.Instance.BackgroundIndex = minigame.minigame.BackgroundIndex;
        PageControl.Instance.minigame = minigame.minigame.minigame;
        PageControl.Instance.Falas = minigame.minigame.Falas;
        PageControl.Instance.FailFalas = minigame.minigame.FailFalas;
        PageControl.Instance.IsGaveta = minigame.minigame.IsGaveta;
        PageControl.Instance.IsOpcoesRapidas = minigame.minigame.IsOpcoesRapidas;
        if (GameState.Instance.PowerUpsActive[0]) PageControl.Instance.Timer = minigame.minigame.Time * 2;
        else PageControl.Instance.Timer = minigame.minigame.Time;
        PageControl.Instance.Pages = minigame.minigame.Pages;
        PageControl.Instance.CurrentPage = minigame.minigame.CurrentPage;
        PageControl.Instance.IsWifiEnabled = minigame.minigame.IsWifiEnabled;
        PageControl.Instance.IsGPSEnabled = minigame.minigame.IsGPSEnabled;
        PageControl.Instance.IsBluetoothEnabled = minigame.minigame.IsBluetoothEnabled;
        PageControl.Instance.IsDadosEnabled = minigame.minigame.IsDadosEnabled;
        PageControl.Instance.IsEnergyEnabled = minigame.minigame.IsEnergyEnabled;
        PageControl.Instance.IsPlaneModeEnabled = minigame.minigame.IsPlaneModeEnabled;
        PageControl.Instance.IsLightEnabled = minigame.minigame.IsLightEnabled;
        PageControl.Instance.lightLevel = minigame.minigame.lightLevel;
        PageControl.Instance.parent = this;
        PageControl.Instance.Activate();
        PageControl.Instance.AjustApps();
    }
}
