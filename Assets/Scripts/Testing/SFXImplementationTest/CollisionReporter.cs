using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFXImplementationTest
{
    public class CollisionReporter : MonoBehaviour
    {
        public CollisionListener[] listeners;

        void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"Report hit!");
            foreach (var listener in listeners)
            {
                listener.OnCollisionEnter(collision);
            }
        }

        void OnCollisionExit(Collision collision)
        {
            Debug.Log($"Report unhit!");
            foreach (var listener in listeners)
            {
                listener.OnCollisionExit(collision);
            }
        }
    }
}