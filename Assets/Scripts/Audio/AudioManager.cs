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

    [Header("���")]
    public AudioSource BGMSource;
    public AudioMixer audioMixer;

    private void OnEnable()
    {
        BGMEvent.OnEventRaised += OnBGMEvent;
        volumeEvent.OnEventRaised += OnVolumeEvent;
    }
    private void OnDisable()
    {
        BGMEvent.OnEventRaised -= OnBGMEvent;
        volumeEvent.OnEventRaised += OnVolumeEvent;
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
