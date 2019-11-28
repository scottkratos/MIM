using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MascoteUpdate : TouchSystem
{
    public Image Eyes;
    public Image Pose;
    public TMPro.TextMeshProUGUI Text;

    public void UpdateInfo(Sprite _eyes, Sprite _pose, string _text)
    {
        Eyes.sprite = _eyes;
        Pose.sprite = _pose;
        Text.text = _text;
    }

    protected override void DetectClick()
    {
        base.DetectClick();
        AudioManager.Instance.PlaySFX(1);
        GameState.Instance.UpdateMascote();
    }
    protected override void DetectTouchStayExit()
    {
        base.DetectTouchStayExit();
        AudioManager.Instance.PlaySFX(1);
        GameState.Instance.UpdateMascote();
    }
}
