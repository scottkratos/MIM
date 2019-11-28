using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArquivosRecebidosManager : MonoBehaviour
{
    public GameObject[] Prefabs;
    public GameObject Child;
    [SerializeField]
    private List<int> ids = new List<int>();
    [SerializeField]
    private List<ArquivosLocalizados> sdi = new List<ArquivosLocalizados>();
    public static ArquivosRecebidosManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Show()
    {
        ids.Clear();
        sdi.Clear();
        for (int i = 0; i < Child.transform.childCount; i++)
        {
            Destroy(Child.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < PageControl.Instance.ArquivosTransmitidos.Count; i++)
        {
            if (!ids.Contains(PageControl.Instance.ArquivosTransmitidos[i].ID))
            {
                ids.Add(PageControl.Instance.ArquivosTransmitidos[i].ID);
                ArquivosLocalizados aloc = new ArquivosLocalizados();
                sdi.Add(aloc);
            }
            ArquivosArquivos aa = new ArquivosArquivos();
            aa.Nome = PageControl.Instance.ArquivosTransmitidos[i].Nome;
            aa.Peso = PageControl.Instance.ArquivosTransmitidos[i].Peso;
            aa.Data = PageControl.Instance.ArquivosTransmitidos[i].Data;
            sdi[ids.IndexOf(PageControl.Instance.ArquivosTransmitidos[i].ID)].arches.Add(aa);
        }
        for (int i = 0; i < ids.Count; i++)
        {
            GameObject Line = Instantiate(Prefabs[0], Child.transform);
            Line.GetComponent<SenderRow>().Nome = PageControl.Instance.DisBluetooth[ids[i]].Name;
            for (int l = 0; l < sdi[i].arches.Count; l++)
            {
                GameObject Row = Instantiate(Prefabs[1], Child.transform);
                Row.GetComponent<ArchiveRow>().Nome = sdi[i].arches[l].Nome;
                Row.GetComponent<ArchiveRow>().Size = sdi[i].arches[l].Peso;
                Row.GetComponent<ArchiveRow>().Type = sdi[i].arches[l].Data;
            }
        }
    }
}

[System.Serializable]
public class ArquivosLocalizados
{
    public List<ArquivosArquivos> arches = new List<ArquivosArquivos>();
}

[System.Serializable]
public class ArquivosArquivos
{
    public string Nome;
    public float Peso;
    public App.DataType Data;
}
