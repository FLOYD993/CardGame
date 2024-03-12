using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked; //default value is false
    public Image lockImage;
    private void Start()
    {
        //PlayerPrefs.DeleteAll(); �������
    }
    private void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }
    private void UpdateLevelImage()
    {
        if (!unlocked)
        {
            lockImage.gameObject.SetActive(true);
        }
        else
        {
            lockImage.gameObject.SetActive(false);
        }
    }
    private void UpdateLevelStatus()
    {
        int preLevelIndex = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("lv" + preLevelIndex) > 0) //������Ĺ�ͨ�ˣ����������
        {
            unlocked = true;
        }
    }
    public void PressSelection(string _levelNum)
    {
        if(unlocked)
        {
            SceneManager.LoadScene(_levelNum);
        }
    }
}
