using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    

    [Header("�㲥")]
    public VoidEventSO pauseEvent;
    [Header("�¼�����")]
    public FloatEventSO syncVolumeEvent;
    [Header("���")]
    public Button settingsBtn;
    public GameObject pausePanel;
    public Slider volumeSlider;
    private void Awake()
    {
        settingsBtn.onClick.AddListener(TogglePausePanel);
    }
    private void TogglePausePanel()
    {
        if(pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseEvent.RaisedEvent();
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnEnable()
    {
        syncVolumeEvent.OnEventRaised += OnSyncEvent;
    }
    private void OnDisable()
    {
        syncVolumeEvent.OnEventRaised -= OnSyncEvent;
    }

    private void OnSyncEvent(float amount)
    {
        volumeSlider.value = (amount+80) / 100;
    }
}
