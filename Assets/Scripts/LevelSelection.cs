using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    [SerializeField] private Button button;
    public Image lockImage;

    public SceneLoadEventSO loadEventSO;
    public GameSceneSO sceneToGo;

    private void Update()
    {
        UpdateLevelImage();
    }
    public void UpdateLevelImage()
    {
        if (!unlocked)
        {
            button.interactable = false;
            lockImage.gameObject.SetActive(true);
        }
        else
        {
            button.interactable = true;
            lockImage.gameObject.SetActive(false);
        }
    }
    public void SwitchScene()
    {
        loadEventSO.RaiseLoadRequestEvent(sceneToGo, true);
    }
}
