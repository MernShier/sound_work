using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class AudioVolumeController : MonoBehaviour
{
    [SerializeField] private GameObject[] audioSources, Sliders;
    [SerializeField] private Toggle[] Toggles;
    [SerializeField] private GameObject audioSourceMusic;
    [SerializeField] private bool musicTogglerChecker = true, otherSoundsTogglerChecker = true;
    [SerializeField] private float musicSliderValue, otherSliderValue;
    [SerializeField] private AudioMixerGroup Mixer;
    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetFloat("save"));

        {
            if (PlayerPrefs.GetInt("settingChanged0") == 1)
            {
                Sliders[0].GetComponent<Slider>().value = PlayerPrefs.GetFloat("saveSlider0value");
            }

            if (PlayerPrefs.GetInt("settingChanged1") == 1)
            {
                Sliders[1].GetComponent<Slider>().value = PlayerPrefs.GetFloat("saveSlider1value");
            }

            if (PlayerPrefs.GetFloat("saveToggle0value") == 1)
            {
                Toggles[0].isOn = false;
                Debug.Log("qwezxc");
            }
            if (PlayerPrefs.GetFloat("saveToggle1value") == 1)
            {
                Toggles[1].isOn = false;
                Debug.Log("qwezxc1");
            }
        }
    }
    public void MusicToggler()
    {
        if (musicTogglerChecker == true)
        {
            audioSourceMusic.GetComponent<AudioSource>().volume = 0;
            musicTogglerChecker = false;
        }
        else
        {
            audioSourceMusic.GetComponent<AudioSource>().volume = Sliders[0].GetComponent<Slider>().value;
            musicTogglerChecker = true;
        }
    }
    public void otherSoundsToggler()
    {
        if (otherSoundsTogglerChecker == true)
        {
            foreach (GameObject audioSource in audioSources)
            {
                audioSource.GetComponent<AudioSource>().volume = 0;
            }
            otherSoundsTogglerChecker = false;
        }
        else
        {
            foreach (GameObject audioSource in audioSources)
            {
                audioSource.GetComponent<AudioSource>().volume = Sliders[1].GetComponent<Slider>().value;
            }
            otherSoundsTogglerChecker = true;
        }
    }
    public void MusicSlider()
    {
        if (musicTogglerChecker == true)
        {
            audioSourceMusic.GetComponent<AudioSource>().volume = Sliders[0].GetComponent<Slider>().value;
        }
    }
    public void otherSoundsSlider()
    {
        if (otherSoundsTogglerChecker == true)
        {
            foreach (GameObject audioSource in audioSources)
            {
                audioSource.GetComponent<AudioSource>().volume = Sliders[1].GetComponent<Slider>().value;
            }
        }
    }
    //-----------------------------------
    public void backGroundDistortion()
    {
        Mixer.audioMixer.SetFloat("BackgroundDistortion", 0.5f);
        CancelInvoke("backGroundDistortionZero");
        Invoke("backGroundDistortionZero", 0.5f);
    }
    public void backGroundDistortionZero()
    {
        Mixer.audioMixer.SetFloat("BackgroundDistortion", 0);
    }
    //-----------------------------------
    public void saveSliderValue(int i)
    {
        if (i == 0)
        {
            PlayerPrefs.SetInt("settingChanged0", 1);
            PlayerPrefs.SetFloat("saveSlider0value", Sliders[0].GetComponent<Slider>().value);
        }
        else if (i == 1)
        {
            PlayerPrefs.SetInt("settingChanged1", 1);
            PlayerPrefs.SetFloat("saveSlider1value", Sliders[1].GetComponent<Slider>().value);
        }

        Debug.Log(PlayerPrefs.GetFloat("saveSlider0value"));
        Debug.Log(PlayerPrefs.GetFloat("saveSlider1value"));
    }
    public void SaveToggleValue(int i)
    {

        if (i == 0)
        {
            if (Toggles[0].isOn == false)
            {
                PlayerPrefs.SetFloat("saveToggle0value", 1);
            }
            else
            {
                PlayerPrefs.SetFloat("saveToggle0value", 0);
            }
        }
        else if (i == 1)
        {
            if (Toggles[1].isOn == false)
            {
                PlayerPrefs.SetFloat("saveToggle1value", 1);
            }
            else
            {
                PlayerPrefs.SetFloat("saveToggle1value", 0);
            }
        }
        Debug.Log("SaveToggle0 = " + PlayerPrefs.GetFloat("saveToggle0value"));
        Debug.Log("SaveToggle1 = " + PlayerPrefs.GetFloat("saveToggle1value"));
    }
}
