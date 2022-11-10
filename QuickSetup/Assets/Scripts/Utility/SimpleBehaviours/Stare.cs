using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VirtualDeviants.Utility.SimpleBehaviours
{
    [ExecuteInEditMode]
    public class Stare : MonoBehaviour
    {

        public Transform target;

        private void LateUpdate()
        {
            if (target == null) return;

            transform.LookAt(target);
        }

    }
}
