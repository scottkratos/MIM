using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoLock : MonoBehaviour
{
    public float Rate;
    public bool CanChange;
    public float Delay;
    private float minorDelay;
    private MacroLevel[] Levels;
    private ScrollRect scroll;
    public static AutoLock Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Levels = FindObjectsOfType<MacroLevel>();
        scroll = GetComponent<ScrollRect>();
    }
    private void Update()
    {
        if (GameState.Instance.SimActivated) return;
        CanChange = !(Mathf.Abs(scroll.velocity.x) + Mathf.Abs(scroll.velocity.y) > 0);
        if (!CanChange)
        {
            minorDelay = 0;
            return;
        }
        if (minorDelay >= Delay)
        {
            float Minor = 10000;
            float ForceX = 0;
            float ForceY = 0;
            bool NeedForce = false;
            foreach (MacroLevel _level in Levels)
            {
                if (Vector2.Distance(-scroll.content.transform.localPosition, new Vector2(_level.GetComponent<RectTransform>().anchoredPosition.x, _level.GetComponent<RectTransform>().anchoredPosition.y)) < Minor)
                {
                    Minor = Vector2.Distance(-scroll.content.transform.localPosition, new Vector2(_level.GetComponent<RectTransform>().anchoredPosition.x, _level.GetComponent<RectTransform>().anchoredPosition.y));
                    if (Vector2.Distance(-scroll.content.transform.localPosition, new Vector2(_level.GetComponent<RectTransform>().anchoredPosition.x, _level.GetComponent<RectTransform>().anchoredPosition.y)) < 700)
                    {
                        ForceX = 0;
                        ForceY = 0;
                        Minor = 0;
                        NeedForce = false;
                        break;
                    }
                    NeedForce = true;
                    ForceX = _level.GetComponent<RectTransform>().anchoredPosition.x;
                    ForceY = _level.GetComponent<RectTransform>().anchoredPosition.y;
                }

            }
            if (NeedForce) scroll.normalizedPosition = new Vector2(((scroll.content.sizeDelta.x / 2) + ForceX) / scroll.content.sizeDelta.x, ((scroll.content.sizeDelta.y / 2) + ForceY) / scroll.content.sizeDelta.y);
        }
        else
        {
            minorDelay += Time.deltaTime;
        }
    }
    public void NextLesson()
    {
        int index = 0;
        foreach (MacroLevel _level in Levels)
        {
            if (_level.IsDone)
            {
                if (index < _level.ID) index = _level.ID;
            }
        }
        float Minor = 0;
        float ForceX = 0;
        float ForceY = 0;
        foreach (MacroLevel _level in Levels)
        {
            if (index == 23)
            {
                Minor = Vector2.Distance(-scroll.content.transform.localPosition, new Vector2(_level.GetComponent<RectTransform>().anchoredPosition.x, _level.GetComponent<RectTransform>().anchoredPosition.y));
                ForceX = _level.GetComponent<RectTransform>().anchoredPosition.x;
                ForceY = _level.GetComponent<RectTransform>().anchoredPosition.y;
                break;
            }
            if (_level.ID == index + 1)
            {
                Minor = Vector2.Distance(-scroll.content.transform.localPosition, new Vector2(_level.GetComponent<RectTransform>().anchoredPosition.x, _level.GetComponent<RectTransform>().anchoredPosition.y));
                ForceX = _level.GetComponent<RectTransform>().anchoredPosition.x;
                ForceY = _level.GetComponent<RectTransform>().anchoredPosition.y;
            }
        }
        scroll.normalizedPosition = new Vector2(((scroll.content.sizeDelta.x / 2) + ForceX) / scroll.content.sizeDelta.x, ((scroll.content.sizeDelta.y / 2) + ForceY) / scroll.content.sizeDelta.y);
        foreach (Level _level in FindObjectsOfType<Level>())
        {
            _level.LocalPrefab.SetActive(false);
        }
    }
}
