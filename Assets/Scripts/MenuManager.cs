using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("���뵭��Ч��")]
    public RawImage rawImage;
    public float fadeSpeed = 1.5f; //�ٶ�
    private bool isFade = true; //�Ƿ���Ч��

    [Header("�����������")]
    public GameObject aboutusPanel;

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
    private void FadeIn()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    private void FadeOut()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }
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
    private IEnumerator FadeOutCoroutine()
    {
        rawImage.enabled = true;
        while (rawImage.color.a <= 0.96f)
        {
            FadeOut();
            yield return null;
        }
        SceneManager.LoadScene("Persistent Scene");
    }
    
    public void StartGame()
    {
        StartCoroutine(FadeOutCoroutine());
    }
    public void ShowSettings()
    {

    }
    public void ShowAboutUS()
    {
        aboutusPanel.SetActive(true);
    }
    public void ExitAboutUS()
    {
        aboutusPanel.SetActive(false);
    }
}
