using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Arquivo", menuName = "Arquivos Transmitidos")]
public class ArchTransfer : ScriptableObject
{
    public string Nome;
    public App.DataType Data;
    public float Peso;
    public Sprite Thumbnail;
    public int ID;
}