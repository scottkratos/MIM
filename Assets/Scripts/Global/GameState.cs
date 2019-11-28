using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;
    public CelType CT;
    //MASCOTE
    public bool SimActivated;
    private MascoteUpdate PrefabMascote;
    [SerializeField]
    private MascoteFalas falas;
    public MascoteFalas fim;
    public MascoteFalas loja;
    public MascoteFalas intro2;
    public MascoteFalas invent;
    public MascoteFalas aprimoramento;
    public bool HasLoja;
    public bool HasInvent;
    public bool HasAprimor;
    private int FalasIndex;
    //
    public bool EasterEgg;
    public PlayerData data;
    public bool[] PowerUpsActive;
    public int[] PowerUpsCount;
    public int[] timer;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PrefabMascote = FindObjectOfType<MascoteUpdate>();
        AudioManager.Instance.PlayMusic(0);
        if (SaveSystem.LoadData() != null)
        {
            data = SaveSystem.LoadData();
            RemoveMascote();
            foreach (MacroLevel ml in FindObjectsOfType<MacroLevel>())
            {
                ml.level.IsDone = data.LevelData[ml.ID - 1];
                ml.IsDone = data.LevelData[ml.ID - 1];
            }
            PowerUpsActive = data.PowerUpsActive;
            PowerUpsCount = data.PowerUpsCount;
            timer = data.PowerTimer;
            HasAprimor = data.HasEnteredAprimor;
            HasInvent = data.HasEnteredInvent;
            HasLoja = data.HasEnteredLoja;
            StartCoroutine(DelayedLock());
        }
        else
        {
            StartMascote(falas);
            PowerUpsActive = new bool[4];
            PowerUpsCount = new int[4];
            timer = new int[4];
            Save();
        }
    }
    public IEnumerator DelayToFinish(int index)
    {
        while (timer[index] > 0)
        {
            yield return new WaitForSeconds(1);
            timer[index]--;
            Save();
        }
        PowerUpsActive[index] = false;
        LojaManager.AvaiableCorots[index] = null;
    }
    private IEnumerator DelayedLock()
    {
        yield return new WaitForEndOfFrame();
        AutoLock.Instance.NextLesson();
        for (int i = 0; i < PowerUpsActive.Length; i++)
        {
            if (PowerUpsActive[i]) LojaManager.AvaiableCorots[i] = StartCoroutine(DelayToFinish(i));
        }
    }
    public void Save()
    {
        bool[] lcalbool = new bool[FindObjectsOfType<MacroLevel>().Length];
        foreach (MacroLevel ml in FindObjectsOfType<MacroLevel>())
        {
            lcalbool[ml.ID - 1] = ml.IsDone;
        }
        SaveSystem.PlayerSave(lcalbool, PowerUpsActive, PowerUpsCount, timer, HasLoja, HasInvent, HasAprimor);
    }
    public void StartMascote(MascoteFalas _falas)
    {
        if (_falas == null) return;
        falas = _falas;
        FalasIndex = 0;
        PrefabMascote.gameObject.SetActive(true);
        SimActivated = true;
        UpdateMascote();
    }
    public void UpdateMascote()
    {
        for (int i = 0; i < PrefabMascote.transform.childCount; i++)
        {
            if (i == 0) continue;
            if (i == 1) continue;
            if (i == 2) continue;
            Destroy(PrefabMascote.transform.GetChild(i).gameObject);
        }
        if (FalasIndex < falas.Falas.Length)
        {
            PrefabMascote.UpdateInfo(falas.Falas[FalasIndex].Face, falas.Falas[FalasIndex].Pose, falas.Falas[FalasIndex].Text);
            if (falas.Falas[FalasIndex].Prefab != null) Instantiate(falas.Falas[FalasIndex].Prefab, PrefabMascote.transform);
            FalasIndex++;
        }
        else
        {
            RemoveMascote();
        }
    }
    public void RemoveMascote()
    {
        SimActivated = false;
        PrefabMascote.gameObject.SetActive(false);
        if (PageControl.Instance != null)
        {
            if (PageControl.Instance.gameObject.activeSelf)
            {
                AudioManager.Instance.PlayMusic(2);
                PageControl.Instance.CheckComplete();
            }
        }
    }
    public enum Minigames
    {
        Chrome,
        WhatsApp,
        IntroWifi,
        WifiFacil,
        WifiMedio,
        WifiDificil,
        IntroDadosMoveis,
        DadosMoveisFacil,
        DadosMoveisMedio,
        DadosMoveisDificil,
        ModoAviao,
        Remix1,
        IntroBluetooth,
        BluetoothFacil,
        BluetoothMedio,
        ArmazenamentoIntro,
        ContaGoogle,
        InstallApp,
        UninstallApp,
        PurchaseApp,
        Remix2,
        Remix3,
        Remix4
    }
    public enum CelType
    {
        Samsung,
        LG,
        Google
    }
}
