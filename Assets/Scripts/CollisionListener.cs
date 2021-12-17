using UnityEngine;

public abstract class CollisionListener : MonoBehaviour
{
    public abstract void OnCollisionEnter(Collision collision);
    public abstract void OnCollisionExit(Collision collision);
}
