using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Arquivo", menuName = "Arquivos")]

public class ArchSystem : ScriptableObject
{
    public string Nome;
    public App.DataType Data;
    public float Peso;
    public Sprite Thumbnail;
}