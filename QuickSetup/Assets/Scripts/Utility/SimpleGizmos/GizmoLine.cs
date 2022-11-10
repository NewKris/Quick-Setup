using UnityEngine;

namespace VirtualDeviants.Utility.SimpleGizmos
{

#if UNITY_EDITOR
	public class GizmoLine : MonoBehaviour
	{

		public Transform start;
		public Transform end;

		[Space]
		
		public Color color = Color.red;
		public float thickness = 1;

		[Space]

		public bool alwaysDraw = true;
		public bool dotted = false;

		private void OnDrawGizmos()
		{
			if(!alwaysDraw) return;
			DrawLine();
		}

		private void OnDrawGizmosSelected()
		{
			if(alwaysDraw) return;
			DrawLine();
		}

		private void DrawLine()
		{
			if(!start || !end) return;
			
			UnityEditor.Handles.color = color;
			
			if(dotted) UnityEditor.Handles.DrawDottedLine(start.position, end.position, thickness);
			else UnityEditor.Handles.DrawLine(start.position, end.position, thickness);
		}
		

	}
#endif
}