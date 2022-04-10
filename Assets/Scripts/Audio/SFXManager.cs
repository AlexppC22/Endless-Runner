using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AgTech
{
    public class SFXManager : MonoBehaviour
    {
        public static SFXManager instance;
        public AudioSource audioSource;

        private void Awake() {
            if(instance == null)
                instance = this;
            else
                Destroy(this);
        }

        public void PlaySFX(AudioClip clip)
        {   
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}

