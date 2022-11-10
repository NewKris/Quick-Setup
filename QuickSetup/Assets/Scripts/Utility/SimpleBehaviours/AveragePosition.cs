using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualDeviants.Utility.SimpleBehaviours
{
    public class AveragePosition : MonoBehaviour
    {
        public List<Transform> targets;
        public bool lockYAxis;

        private float _invCount;

        private void Start()
        {
            if (targets.Count == 0) return;

            _invCount = 1f / targets.Count;
        }

        private void LateUpdate()
        {
            Vector3 averagePosition = Vector3.zero;
            for (int i = 0; i < targets.Count; i++)
                averagePosition += targets[i].position;

            averagePosition *= _invCount;

            if (lockYAxis) averagePosition.y = 0;

            transform.position = averagePosition;
        }

        public void AddTarget(Transform target)
        {
            targets.Add(target);
            _invCount = 1 / targets.Count;
        }

        public void RemoveTarget(Transform target)
        {
            targets.Remove(target);

            if (targets.Count == 0)
                _invCount = 0;
            else
                _invCount = 1 / targets.Count;
        }

    }
}
