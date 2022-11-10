using System;
using UnityEngine;
using VirtualDeviants.Utility.Attributes;

namespace VirtualDeviants.Levels
{
	[RequireComponent(typeof(BoxCollider))]
	public class LevelTrigger : MonoBehaviour
	{
		
		public static event Action<string[]> OnPlayerEnteredTrigger;


		[SceneReference, Tooltip("Which Levels should load when this is triggered.")]
		public string[] levels;

		private void OnValidate()
		{
			GetComponent<BoxCollider>().isTrigger = true;
		}

		private void OnTriggerEnter(Collider other)
		{
			if(other.CompareTag("Player"))
				OnPlayerEnteredTrigger?.Invoke(levels);
		}
	}
}