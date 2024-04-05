using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSider;
    [SerializeField] private Slider SFXSider;


    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolum();
            SetSFXVolum();
        }

    }

    public void SetMusicVolum()
    {
        float volume = musicSider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolum()
    {
        float volume = SFXSider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    private void LoadVolume()
    {
        musicSider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolum();
        SetSFXVolum();
    }
}
