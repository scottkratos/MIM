using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nova Fala", menuName = "Falas Mascote")]
public class MascoteFalas : ScriptableObject
{
    public Mascote[] Falas;
}

[System.Serializable]
public class Mascote
{
    [Header("Setup de Texto:")]
    public string Text;
    [Space]
    [Header("Setup do Mascote:")]
    public Sprite Pose;
    public Sprite Face;
    [Space]
    [Header("Setup de exemplo:")]
    public GameObject Prefab;
}