using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{

    public GameObject levelSelectPanel;
    private Button[] levelSelectButtons;
    private int unlockedIndex;

    [SerializeField] private bool isUnlocked;

    public GameSceneSO sceneToGo;

    private void Start()
    {
        unlockedIndex = PlayerPrefs.GetInt("unlockedIndex");
        levelSelectButtons = new Button[levelSelectPanel.transform.childCount];
        for (int i = 0; i < levelSelectButtons.Length; i++)
        {
            levelSelectButtons[i] = levelSelectPanel.transform.GetChild(i).GetComponent<Button>();
        }
        for (int i = 0; i < levelSelectButtons.Length; i++) //未解锁的不可交互
        {
            levelSelectButtons[i].interactable = false;
            //levelSelectButtons[i].image.color = Color.blue;
        }
        for (int i = 0; i < unlockedIndex + 1; i++) //解锁的可交互
        {
            levelSelectButtons[i].interactable = true;
            //levelSelectButtons[i].image.color = Color.red;
        }
    }
    private void Update()
    {
        for(int i = 0; i < levelSelectButtons.Length; i++)
        {
            
        }
    }
    //public void SceneLevel1()
    //{
    //    SceneManager.LoadScene(1);
    //}
    //public void SceneLevel2()
    //{
    //    SceneManager.LoadScene(2);
    //}
    //public void SceneLevel3()
    //{
    //    SceneManager.LoadScene(3);
    //}
}
