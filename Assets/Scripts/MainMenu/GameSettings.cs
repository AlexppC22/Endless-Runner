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
        
        private Resolution[] resolutions;
        private List<string> resolutionOptions = new List<string>();
        private void Start() 
        {      
            SetUpResolutionDropdown();
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
            audioMixer.SetFloat("SFXVolume", volume);
        }

        public void SetMusicVolume(float volume)
        {
            audioMixer.SetFloat("MusicVolume", volume);
        }

        public void ToggleCredits()
        {

        }
    }
}

