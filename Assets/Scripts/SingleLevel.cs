using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{
    //public bool isFinished;
    //private int currentFinishedFlag = 0; //0δ��ɣ�1�����
    public int levelIndex = 0;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void BackButton()
    {
        SceneManager.LoadScene("Persistent Scene");
    }
    public void Finished(int flag)
    {
        PlayerPrefs.SetInt("lv"+levelIndex, flag);
        Debug.Log(PlayerPrefs.GetInt("lv" + levelIndex, flag));
    }
}
