using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void setMasterVolume(float level)
    {
        PlayerPrefs.SetFloat("MasterVolume", level);
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20f);
    }

    public void setSoundFXVolume(float level)
    {
        PlayerPrefs.SetFloat("SFXVolume", level);
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level) * 20f);
    }

    public void setMusicVolume(float level)
    {
        PlayerPrefs.SetFloat("MusicVolume", level);
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20f);
    }
    public void setAmbientVolume(float level)
    {
        PlayerPrefs.SetFloat("AmbienceVolume", level);
        audioMixer.SetFloat("ambientVolume", Mathf.Log10(level) * 20f);
    }
}

