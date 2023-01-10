using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VirtualDeviants.Levels.Editor
{
    public class LevelManagerWindow : EditorWindow
    {

        [MenuItem("Window/Level Manager")]
        public static void ShowWindow()
        {
            GetWindow<LevelManagerWindow>("Level Manager");
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            
            if(GUILayout.Button("Load Levels"))
                LoadLevels();
            
            if(GUILayout.Button("Unload Levels"))
                UnloadLevels();
            
            EditorGUILayout.EndVertical();
        }

        private void LoadLevels()
        {

            EditorSceneManager.SaveOpenScenes();
            
            if(SceneManager.GetSceneAt(0).name != "Gameplay") return;
            
            EditorSceneManager.OpenScene("Assets/Scenes/Gameplay.unity");

            EditorBuildSettingsScene[] levels = EditorBuildSettings.scenes.Where(x => x.path.Contains("Levels")).ToArray();
            foreach (EditorBuildSettingsScene level in levels)
                EditorSceneManager.OpenScene(level.path, OpenSceneMode.Additive);

        }

        private void UnloadLevels()
        {

            EditorSceneManager.SaveOpenScenes();

            int countLoaded = SceneManager.sceneCount;

            if(countLoaded == 1) return;
            
            for (int i = countLoaded - 1; i >= 0; i--)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if(scene.name == "Gameplay") continue;
                
                EditorSceneManager.CloseScene(scene, true);
            }
            
        }
    }
}
