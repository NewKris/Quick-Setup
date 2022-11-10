using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualDeviants.Core;

namespace VirtualDeviants.UI
{
    public class MainMenuController : MonoBehaviour
    {
        public void StartGame()
        {
            SceneLoader.LoadGameplay();
        }

        public void ExitGame()
        {
            GameManager.ExitGame();
        }
    }
}
