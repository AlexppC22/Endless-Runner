using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace AgTech
{
    public class GameSettings : MonoBehaviour
    {
        public AudioMixer sfxMixer;
        public AudioMixer musicMixer;
        public void ToggleFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        public void SetResolution()
        {

        }

        public void SetSFXVolume(float volume)
        {
            sfxMixer.SetFloat("SFXVolume", volume);
        }

        public void SetMusicVolume(float volume)
        {
            sfxMixer.SetFloat("MusicVolume", volume);
        }

        public void ToggleCredits()
        {

        }
    }
}

