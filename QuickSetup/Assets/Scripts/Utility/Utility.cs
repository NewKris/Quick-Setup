using System.Collections.Generic;
using UnityEngine;

namespace VirtualDeviants.Utility
{

    public static class VectorExtensions
    {
        public static float YAngle(this Vector3 vector)
        {
            return Mathf.Atan2(vector.x, vector.z) * Mathf.Rad2Deg;
        }
    }

	public static class MonoBehaviourExtensions
	{
		public static Vector3 Position(this MonoBehaviour component)
		{
			return component.transform.position;
		}

		public static Quaternion Rotation(this MonoBehaviour component)
		{
			return component.transform.rotation;
		}

		public static Vector3 Scale(this MonoBehaviour component)
		{
			return component.transform.localScale;
		}

	}

    public struct DampedValue
	{
		private float _current;
		private float _target;
		private float _velocity;

		public float Current => _current;

		public float Target
		{
			get => _target;
			set => _target = value;
		}

		public DampedValue(float startValue)
		{
			_current = startValue;
			_target = startValue;
			_velocity = 0;
		}

		public void Tick(float damping)
		{
			_current = Mathf.SmoothDamp(_current, _target, ref _velocity, damping);
		}

		public void TickAngle(float damping)
		{
			_current = Mathf.SmoothDampAngle(_current, _target, ref _velocity, damping);
		}
		
	}
	
	public struct DampedVector
	{
		private Vector3 _current;
		private Vector3 _target;
		private Vector3 _velocity;

		public Vector3 Current => _current;

		public Vector3 Target
		{
			get => _target;
			set => _target = value;
		}

		public DampedVector(Vector3 startValue)
		{
			_current = startValue;
			_target = startValue;
			_velocity = Vector3.zero;
		}

		public void Tick(float damping)
		{
			_current = Vector3.SmoothDamp(_current, _target, ref _velocity, damping);
		}
	}

	public readonly struct TimeKeeper
	{
		private readonly Dictionary<string, float> _timers;

		public float this[string timerName] => _timers[timerName];
		
		public void AddTimer(string timerName, float startValue = 0)
		{
			_timers.Add(timerName, startValue);
		}

		public void RemoveTimer(string targetTimer)
		{
			if (_timers.ContainsKey(targetTimer)) _timers.Remove(targetTimer);
		}

		public void TickTimers(float dt)
		{
			foreach (string timer in _timers.Keys)
				_timers[timer] += dt;
		}

	}
	
}