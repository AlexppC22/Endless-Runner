using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace AgTech
{
    public class MainMenuButtons : MonoBehaviour
    {
        [SerializeField] CanvasGroup optionsCanvasGroup;
        public void QuitGame()
        {
            Debug.Log("<color=red>QuitGame</color>");
            Application.Quit();
        }

        public void StartGame()
        {
            Debug.Log("<color=blue>Play Game</color>");
            //Check for Saved Game
            //If there is, load Game
            //Else, create new Game
            //Load Game Scene
        }

        public void ToggleOptionsMenu()
        {
            if(optionsCanvasGroup.alpha > 0)
            {
                optionsCanvasGroup.alpha = 0;
                optionsCanvasGroup.interactable = false;
                optionsCanvasGroup.blocksRaycasts = false;
            }
            else
            {
                optionsCanvasGroup.alpha = 1;
                optionsCanvasGroup.interactable = true;
                optionsCanvasGroup.blocksRaycasts = true;
            }
        }
    }
}

