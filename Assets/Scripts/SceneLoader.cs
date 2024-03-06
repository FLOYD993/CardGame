using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("ÊÂ¼þ¼àÌý")]
    public SceneLoadEventSO loadEventSO;
    public GameSceneSO firstLoadScene;

    private GameSceneSO sceneToLoad;
    private bool fadeScreen;
    private void Awake()
    {
        Addressables.LoadSceneAsync(firstLoadScene.sceneReference, LoadSceneMode.Additive);
    }
    private void OnEnable()
    {
        loadEventSO.LoadRequestEvent += OnLoadRequestEvent;
    }
    private void OnDisable()
    {
        loadEventSO.LoadRequestEvent -= OnLoadRequestEvent;
    }
    private void OnLoadRequestEvent(GameSceneSO locationToGo, bool fadeScreen)
    {
        sceneToLoad = locationToGo;
        this.fadeScreen = fadeScreen;

        Debug.Log(sceneToLoad.sceneReference.SubObjectName);
    }
}
