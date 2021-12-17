using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SFXImplementationTest
{
    public abstract class CollisionListener : MonoBehaviour
    {
        public abstract void OnCollisionEnter(Collision collision);
        public abstract void OnCollisionExit(Collision collision);
    }
}