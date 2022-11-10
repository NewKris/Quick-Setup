using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace VirtualDeviants.Core
{
	public class CoreCaller : MonoBehaviour
	{
		private void Awake()
		{
			if (!GameManager.HasInstance)
			{
				GameManager.quickStart = true;
				SceneManager.LoadScene("Core", LoadSceneMode.Additive);
			}
		}
	}
}