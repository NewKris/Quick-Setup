using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VirtualDeviants.Levels
{
    public class LevelLoader : MonoBehaviour
    {

        private List<string> _loadedLevels;

        private void Awake()
        {
            _loadedLevels = GetLoadedLevels();
            LevelTrigger.OnPlayerEnteredTrigger += LoadLevels;
        }

        private void OnDestroy()
        {
            LevelTrigger.OnPlayerEnteredTrigger -= LoadLevels;
        }

        private void LoadLevels(string[] targetLevels)
        {
            
            string[] levelsToUnload = _loadedLevels.Except(targetLevels).ToArray();
            for (int i = 0; i < levelsToUnload.Length; i++)
            {
                _loadedLevels.Remove(levelsToUnload[i]);
                SceneManager.UnloadSceneAsync(levelsToUnload[i]);
            }
            
            string[] levelsToLoad = targetLevels.Except(_loadedLevels).ToArray();
            for (int i = 0; i < levelsToLoad.Length; i++)
            {
                _loadedLevels.Add(levelsToLoad[i]);
                SceneManager.LoadSceneAsync(levelsToLoad[i], LoadSceneMode.Additive);
            }
        }

        private List<string> GetLoadedLevels()
        {

            List<string> loadedLevels = new List<string>();

            int loadCount = SceneManager.sceneCount;
            for (int i = 0; i < loadCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (!scene.path.Contains("Levels")) continue;
                
                loadedLevels.Add(scene.name);
            }

            return loadedLevels;
        }
    }
}
