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
}
