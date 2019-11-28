using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontSelector : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_FontAsset[] fonts;

    private void Start()
    {
        TMPro.TMP_Text[] comps;
        comps = Resources.FindObjectsOfTypeAll(typeof(TMPro.TMP_Text)) as TMPro.TMP_Text[];
        switch (GameState.Instance.CT)
        {
            default:
                foreach (TMPro.TMP_Text _comp in comps)
                {
                    _comp.font = fonts[0];
                }
                break;
            case GameState.CelType.Google:
                foreach (TMPro.TMP_Text _comp in comps)
                {
                    _comp.font = fonts[0];
                }
                break;
            case GameState.CelType.LG:
                foreach (TMPro.TMP_Text _comp in comps)
                {
                    _comp.font = fonts[0];
                }
                break;
            case GameState.CelType.Samsung:
                foreach (TMPro.TMP_Text _comp in comps)
                {
                    _comp.font = fonts[1];
                }
                break;
        }
    }
}
