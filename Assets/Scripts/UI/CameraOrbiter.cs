using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbiter : MonoBehaviour
{
    float rot_y = 0f;

    [SerializeField] Transform target;
    [SerializeField] float orbitDistance;
    [SerializeField] float orbitSpeed = 1f;

    // Vector3 currRot;
    // Vector3 smoothVelocity = Vector3.zero;
    // float smoothTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rot_y += orbitSpeed;

        if (rot_y > 360)
        {
            rot_y -= 360;
        }

        // Vector3 nextRot = new Vector3(transform.eulerAngles.x, rot_y, )

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rot_y, transform.eulerAngles.z);
        transform.position = target.position - transform.forward * orbitDistance;
    }
}
