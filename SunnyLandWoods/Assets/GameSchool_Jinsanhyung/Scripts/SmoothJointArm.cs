using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jinsanhyoung
{
    public class SmoothJointArm : MonoBehaviour
    {
        public Transform target;
        public float smoothTime = 0.3F;
        public Vector3 offset = new Vector3(0, 0, -10);
        private Vector3 velocity = Vector3.zero;

        void Update()
        {

            if (target == null)
                return;

            // Define a target position above and behind the target ransform
            Vector3 targetPosition = target.TransformPoint(offset);

            // Smotthly move the camera towards that target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
                ref velocity, smoothTime);
        }
    }
}