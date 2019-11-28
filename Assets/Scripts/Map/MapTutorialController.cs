using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTutorialController : MonoBehaviour
{
    public bool STARMAN;
    private MapTutorial child;

    private void Start()
    {
        child = GetComponentInChildren<MapTutorial>();
    }
    private void Update()
    {
        child.gameObject.SetActive(!child.Reference.IsDone && !GameState.Instance.SimActivated && !child.Reference.IsLocked && (STARMAN == child.Reference.LocalPrefab.activeSelf));
    }
}
