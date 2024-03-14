using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingleLevel : MonoBehaviour
{
    //public bool isFinished;
    //private int currentFinishedFlag = 0; //0δ��ɣ�1�����
    public int levelIndex = 0;

    [Header("�������뵭��")]
    public float fadeSpeed = 1.5f; //�ٶ�
    private bool isFade = true; //�Ƿ���Ч��
    public RawImage rawImage;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Start()
    {
        rawImage.uvRect = new Rect(0, 0, Screen.width, Screen.height);
    }
    private void Update()
    {
        if (isFade)
        {
            StartScene();
        }
    }
    public void BackButton()
    {
        StartCoroutine(TransitionToLevel());
    }
    public void Finished(int flag)
    {
        PlayerPrefs.SetInt("lv"+levelIndex, flag);
        Debug.Log(PlayerPrefs.GetInt("lv" + levelIndex, flag));
    }
    private void FadeIn()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    //��Ļ����
    public void FadeOut()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }
    //��Ϸ��ʼʱ
    private void StartScene()
    {
        FadeIn();
        if (rawImage.color.a <= 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            isFade = false;
        }
    }
    //��Ϸ�˳�ʱ
    private IEnumerator TransitionToLevel()
    {
        rawImage.enabled = true;
        while (rawImage.color.a <= 0.96f)
        {
            FadeOut();
            yield return null;
        }
        SceneManager.LoadScene("Main Scene");
    }
}
