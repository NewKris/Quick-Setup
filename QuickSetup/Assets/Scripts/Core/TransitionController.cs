using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualDeviants.Core
{
	public class TransitionController : MonoBehaviour
	{

		public Image blackScreen;
		
		public IEnumerator FadeIn(float t = 0.5f)
		{
			yield return Fade(Color.black, Color.clear, t);
		}

		public IEnumerator FadeOut(float t = 0.5f)
		{
			yield return Fade(Color.clear, Color.black, t);
		}

		private IEnumerator Fade(Color from, Color to, float t)
		{
			float timer = 0;
			while (timer <= t)
			{
				blackScreen.color = Color.Lerp(from, to, timer / t);
				
				timer += Time.deltaTime;
				yield return null;
			}

			blackScreen.color = to;
		}
		
	}
}