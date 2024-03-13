using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public bool unlocked; //default value is false
    public Image lockImage;

    [Header("���뵭��Ч��")]
    public RawImage rawImage;
    public float fadeSpeed = 1.5f; //�ٶ�
    private bool isFade = true; //�Ƿ���Ч��
    private void Start()
    {
        //rawImage = GetComponent<RawImage>();
        //��ͼƬ����Ϊ��Ļ��С
        rawImage.uvRect = new Rect(0, 0, Screen.width, Screen.height);

        //PlayerPrefs.DeleteAll(); //�������
    }
    private void Update()
    {
        if (isFade)
        {
            StartCoroutine(FadeInCoroutine());
        }
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
    private void FadeIn()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    //��Ļ����
    public void FadeOut()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }
    //��Ϸ�˳�FadeOut
    public void PressSelection(string _levelNum)
    {
        if (unlocked)
        {
            StartCoroutine(FadeOutCoroutine(_levelNum));
        }
    }
    private IEnumerator FadeOutCoroutine(string _levelNum)
    {
        rawImage.enabled = true;
        while (rawImage.color.a <= 0.96f)
        {
            FadeOut();
            yield return null;
        }
        SceneManager.LoadScene(_levelNum);
    }
    //��Ϸ��ʼFadeIn
    private IEnumerator FadeInCoroutine()
    {
        rawImage.enabled = true;
        while (rawImage.color.a > 0.05f)
        {
            FadeIn();
            yield return null;
        }
        rawImage.color = Color.clear;
        rawImage.enabled = false;
        isFade = false;
    }
}
