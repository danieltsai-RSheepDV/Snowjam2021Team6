using UnityEngine;

public class CollisionReporter : MonoBehaviour
{
    public CollisionListener[] listeners;

    void OnCollisionEnter(Collision collision)
    {
        foreach (var listener in listeners)
        {
            listener.OnCollisionEnter(collision);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        foreach (var listener in listeners)
        {
            listener.OnCollisionExit(collision);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        foreach (var listener in listeners)
        {
            listener.OnTriggerEnter(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        foreach (var listener in listeners)
        {
            listener.OnTriggerExit(other);
        }
    }
}
