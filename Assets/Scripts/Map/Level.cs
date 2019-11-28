using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level : TouchSystem
{
    [Header("Configurações:")]
    public int ID;
    public MascoteFalas[] Falas;
    public bool IsDone;
    public string Titulo;
    public string Desc;
    public bool IsLocked;
    [Space]
    [Header("Constantes:")]
    public GameObject LocalPrefab;
    public GameObject Check;
    public GameObject Lock;
    public Image Base;
    public Image Linha;
    public Sprite[] sprites;
    public TMPro.TextMeshProUGUI Tit;
    public TMPro.TextMeshProUGUI Description;
    public GameObject Line;
    public Level[] levels;
    
    private void Start()
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = ID.ToString();
        levels = FindObjectsOfType<Level>();
        Tit.text = Titulo;
        Description.text = Desc;
    }
    protected override void Update()
    {
        base.Update();
        if (ID != 1)
        {
            foreach (Level _level in levels)
            {
                if (_level.ID == ID - 1)
                {
                    IsLocked = !_level.IsDone;
                    break;
                }
            }
        }
        Check.SetActive(IsDone);
        Lock.SetActive(IsLocked);
        if (IsDone)
        {
            Base.sprite = sprites[1];
            Linha.sprite = sprites[3];
            if (!Line.activeSelf) return;
        }
        else
        {
            Base.sprite = sprites[0];
            Linha.sprite = sprites[2];
            if (!Line.activeSelf) return;
        }
    }
    protected override void DetectClick()
    {
        base.DetectClick();
        if (IsLocked) return;
        AudioManager.Instance.PlaySFX(0);
        foreach (Level _level in levels)
        {
            if (_level == this) continue;
            _level.LocalPrefab.SetActive(false);
        }
        LocalPrefab.SetActive(!LocalPrefab.activeSelf);
    }
}
