using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System.Linq;

namespace AgTech
{
    public class GameSettings : MonoBehaviour
    {
        public AudioMixer audioMixer;
        public TMP_Dropdown resolutionDropdown;
        [SerializeField] Slider sfxSlider;
        [SerializeField] Slider musicSlider;
        private Resolution[] resolutions;
        private List<string> resolutionOptions = new List<string>();
        private void Start() 
        {      
            SetUpResolutionDropdown();
            SetUpAudioScrollers();
        }

        private void SetUpAudioScrollers()
        {
            // sfxSlider.value = audioMixer.GetFloat("SFXVolume");
            // musicSlider.value = audioMixer.GetFloat("MusicVolume", out musicSlider.value);
        }

        public void ToggleFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        private void SetUpResolutionDropdown()
        {
            resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();
            resolutionDropdown.ClearOptions();
            
            int currentIndex = 0;
            for ( int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                resolutionOptions.Add(option);

                if(resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentIndex = i;
                }
            }

            resolutionDropdown.AddOptions(resolutionOptions);
            resolutionDropdown.value = currentIndex;
            resolutionDropdown.RefreshShownValue();
        }

        public void SetResolution(int index)
        {
            Resolution resolution = resolutions[index];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void SetSFXVolume(float volume)
        {
            audioMixer.SetFloat("SFXVolume", Mathf.Log10 (volume) * 20);
        }

        public void SetMusicVolume(float volume)
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10 (volume) * 20);
        }

        public void ToggleCredits()
        {

        }
    }
}

