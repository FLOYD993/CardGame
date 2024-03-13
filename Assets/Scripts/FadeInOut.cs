using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f; //�ٶ�
    private bool isFade = true; //�Ƿ���Ч��
    public RawImage rawImage;

    public bool unlocked_;
    //private void Awake()
    //{
    //    instance = this;
    //}
    private void Start()
    {
        rawImage = GetComponent<RawImage>();
        //��ͼƬ����Ϊ��Ļ��С
        rawImage.uvRect = new Rect(0, 0, Screen.width, Screen.height);
        unlocked_ = GetComponent<LevelSelection>().unlocked;
    }
    private void Update()
    {
        if(isFade)
        {
            StartScene();
        }
    }
    //��Ļ����
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
        if(rawImage.color.a < 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            isFade = false;
        }
    }
    //��Ϸ�˳�ʱ
    public void EndScene()
    {
        rawImage.enabled = true;
        FadeOut();
        //�л�����
    }
    public void PressSelection(string _levelNum)
    {
        if (unlocked_)
        {
            EndScene();
            if (rawImage.color.a > 0.95f)
            {
                SceneManager.LoadScene(_levelNum);
            }
        }
    }
}
