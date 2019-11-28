using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo App", menuName = "Apps")]
public class CreateApp : ScriptableObject
{
    public AppConfig app;
}

[System.Serializable]
public class AppConfig
{
    [Header("Configuracoes:")]
    [Space]
    public string Nome;
    public Sprite[] sprites;
    public App.AppType Type;
    public int Size;
    public App.DataType DataType;
    public float DadosMoveisUsados;
    public float RedeUsada;
    public float DadosPerSec;
}
