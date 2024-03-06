using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    
    public SceneLoadEventSO loadEventSO;
    public GameSceneSO sceneToGo;

    public void SwitchScene()
    {
        loadEventSO.RaiseLoadRequestEvent(sceneToGo, true);
    }
}
