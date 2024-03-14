using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    [Header("�¼�����")]
    public PlayAudioEventSO BGMEvent;
    public FloatEventSO volumeEvent;
    public VoidEventSO pauseEvent;

    [Header("�㲥")]
    public FloatEventSO syncVolumeEvent;

    [Header("���")]
    public AudioSource BGMSource;
    public AudioMixer audioMixer;

    private void OnEnable()
    {
        BGMEvent.OnEventRaised += OnBGMEvent;
        volumeEvent.OnEventRaised += OnVolumeEvent;
        pauseEvent.OnEventRasied += OnPauseEvent;
    }
    private void OnDisable()
    {
        BGMEvent.OnEventRaised -= OnBGMEvent;
        volumeEvent.OnEventRaised -= OnVolumeEvent;
        pauseEvent.OnEventRasied -= OnPauseEvent;
    }

    private void OnPauseEvent()
    {
        float amount;
        audioMixer.GetFloat("MasterVolume", out amount);
        syncVolumeEvent.RaisedEvent(amount);
    }

    private void OnVolumeEvent(float amount)
    {
        audioMixer.SetFloat("MasterVolume", amount * 100 - 80);
    }

    private void OnBGMEvent(AudioClip clip)
    {
        BGMSource.clip = clip;
        BGMSource.Play();
    }
}
