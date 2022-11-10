using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualDeviants.Core
{
    public class GameManager : MonoBehaviour
    {

        public static bool isPaused;
        public static bool quickStart;
        public static event Action OnPause;
        public static event Action OnUnPause;
        private static GameManager Instance;

        public static bool HasInstance => Instance != null;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            if(quickStart) return;
            SceneLoader.LoadMainMenu();
        }

        private void OnDestroy()
        {
            Instance = null;
            quickStart = false;
        }

        public static void Pause()
        {
            isPaused = true;
            OnPause?.Invoke();
        }

        public static void UnPause()
        {
            isPaused = false;
            OnUnPause?.Invoke();
        }

        public static void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        
    }
}
