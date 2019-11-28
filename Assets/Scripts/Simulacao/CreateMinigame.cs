using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Minigame", menuName = "Minigames")]
public class CreateMinigame : ScriptableObject
{
    public Minigame minigame;
}

[System.Serializable]
public class Minigame
{
    [Header("Configuracoes:")]
    [Space]
    [Header("Minigame:")]
    public float Time;
    public MascoteFalas[] Falas;
    public MascoteFalas[] FailFalas;
    public GameState.Minigames minigame;
    [Space]
    [Header("Home:")]
    public bool IsBlocked;
    public int MacroIndex;
    public int MicroIndex;
    [Range(1, 7, order = 1)]
    public int Pages = 1;
    [Range(1, 7, order = 1)]
    public int CurrentPage = 1;
    public List<CreateFake> apps;
    public List<CreateFake> homeapps;
    public int IsGaveta = 1;
    public int IsOpcoesRapidas = 1;
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
    public int RedeConectada = -1;
    [Range(1, 931000000, order = 1)]
    public float ArmazenamentoMaximo = 900;
    [Range(1, 931000000, order = 1)]
    public float DadosMaximos = 900;
    public bool USBTheth;
    public bool BluetoothTeth;
    public bool AllowVPN;
    public PontoDeAcessoWifi PontoDeAcesso;
    public string BluetoothName;
    public DispositivosBluetooth[] DisBluetooth;
    public List<ArchSystem> Arquivos = new List<ArchSystem>();
    public List<ArchTransfer> ArquivosTransmitidos = new List<ArchTransfer>();
    public bool IsNotifyEnabled;
    [Space]
    [Header("Contatos Wpp:")]
    public WhatsAppControl[] Contatos;
    [Header("Config GooglePlay:")]
    public bool IsLogin;
    public string User;
    public string Pass;
}

[System.Serializable]
public class CreateFake
{
    [Range(0, 6, order = 1)]
    public int Pelicula;
    [Range(0, 3, order = 1)]
    public int Line;
    [Range(0, 4, order = 1)]
    public int Slot;
    public CreateApp CApp;
    public App App;
}

[System.Serializable] 
public class FakeArch
{
    public string Nome;
    public App.DataType Data;
    public float Peso;
    public Sprite Thumbnail;
}

[System.Serializable]
public class FakeTransfer
{
    public string Nome;
    public App.DataType Data;
    public float Peso;
    public Sprite Thumbnail;
    public int ID;
}