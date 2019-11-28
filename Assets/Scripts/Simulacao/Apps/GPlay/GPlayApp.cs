using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPlayApp : MonoBehaviour
{
    public CreateApp Reference;

    public void SelectApp()
    {
        NewerFakeApp _app = new NewerFakeApp();
        _app.DadosMoveisUsados = Reference.app.DadosMoveisUsados;
        _app.DadosPerSec = Reference.app.DadosPerSec;
        _app.dataType = Reference.app.DataType;
        _app.Image = Reference.app.sprites[0];
        _app.Name = Reference.app.Nome;
        _app.RedeUsada = Reference.app.RedeUsada;
        _app.Size = Reference.app.Size;
        _app.Type = Reference.app.Type;
        GplayStoreInfo.Instance.UpdateInfo(_app.Name, _app.Image, _app);
        GplayConfig.Instance.EnterSubmenu(3);
    }
}

public class NewerFakeApp
{
    public Sprite Image;
    public string Name;
    public App.AppType Type;
    public App.DataType dataType;
    public int Size;
    public float DadosMoveisUsados;
    public float RedeUsada;
    public float DadosPerSec;
}