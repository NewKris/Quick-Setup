using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VirtualDeviants.Core
{
	public class SceneLoader : MonoBehaviour
	{

		private static bool MainMenuLoaded;
		private static bool GameplayLoaded;
		private static SceneLoader Instance;

		public TransitionController transitionController;

		private void Awake()
		{
			Instance = this;
		}

		private void OnDestroy()
		{
			MainMenuLoaded = false;
			GameplayLoaded = false;
		}

		public static void LoadMainMenu()
		{
			Instance.StartCoroutine(DoLoadMainMenu());
		}
		
		public static void LoadGameplay()
		{
			Instance.StartCoroutine(DoLoadGameplay());
		}

		private static IEnumerator DoLoadMainMenu()
		{
			yield return Instance.transitionController.FadeOut();
			
			if(GameplayLoaded) yield return DoUnloadGameplay();
			
			AsyncOperation loadMainMenu = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
			while (!loadMainMenu.isDone)
				yield return null;

			MainMenuLoaded = true;

			yield return Instance.transitionController.FadeIn();
			
		}

		private static IEnumerator DoUnloadMainMenu()
		{
			AsyncOperation unloadMainMenu = SceneManager.UnloadSceneAsync("MainMenu");
			while (!unloadMainMenu.isDone)
				yield return null;

			MainMenuLoaded = false;
		}

		private static IEnumerator DoLoadGameplay()
		{
			yield return Instance.transitionController.FadeOut();

			if(MainMenuLoaded) yield return DoUnloadMainMenu();
			
			AsyncOperation loadGameplay = SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive);
			while (!loadGameplay.isDone)
				yield return null;

			GameplayLoaded = true;
			
			yield return Instance.transitionController.FadeIn();
		}

		private static IEnumerator DoUnloadGameplay()
		{
			AsyncOperation unloadGameplay = SceneManager.UnloadSceneAsync("Gameplay");
			while (!unloadGameplay.isDone)
				yield return null;

			GameplayLoaded = false;
		}
	}
}