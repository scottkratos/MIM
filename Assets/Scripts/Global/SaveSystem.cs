using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public static class SaveSystem
{
    public static void PlayerSave(bool[] lvls, bool[] pactives, int[] pcount, int[] ptimer, bool loja, bool invent, bool aprimor)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData();
        data.LevelData = lvls;
        data.PowerUpsActive = pactives;
        data.PowerUpsCount = pcount;
        data.PowerTimer = ptimer;
        data.HasEnteredAprimor = aprimor;
        data.HasEnteredInvent = invent;
        data.HasEnteredLoja = loja;
        formatter.Serialize(stream, data);
        stream.Close();

    }
    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/player.save";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}
