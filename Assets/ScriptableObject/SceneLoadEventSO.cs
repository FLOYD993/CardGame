using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/SceneLoadEventSO")]
public class SceneLoadEventSO : ScriptableObject
{
    public UnityAction<GameSceneSO, bool> LoadRequestEvent;
    //locationToLoad 要加载的场景
    //fadeScreen 是否渐入渐出
    public void RaiseLoadRequestEvent(GameSceneSO locationToLoad, bool fadeScreen)
    {
        LoadRequestEvent?.Invoke(locationToLoad, fadeScreen);
    }
}
