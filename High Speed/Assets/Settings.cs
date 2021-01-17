using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
 public AudioMixer audioMixer;
 public TMP_Dropdown dropdownQual;
    public TMP_Dropdown dropdownResol;
    public Slider sliderVol;
    private Resolution[] resolutions;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }

    public void NewGame()
    {
       
    }
    
    void Start()
    {
        resolutions = Screen.resolutions;
        if (dropdownResol != null)
        {
            dropdownResol.ClearOptions();
            int currentresolution=0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                String resol = resolutions[i].width + " x " + resolutions[i].height;
                dropdownResol.options.Add(new TMP_Dropdown.OptionData(resol));

                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentresolution = i;
                }
            }
            dropdownResol.value = currentresolution;
        }
        if (sliderVol != null)
        {
            float volume;
            audioMixer.GetFloat("volume", out volume);
            sliderVol.value = volume;
            Debug.Log(volume);
        }
    }

    

}
