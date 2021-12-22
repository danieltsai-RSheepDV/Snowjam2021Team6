using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDIsplayBackground : MonoBehaviour
{
    Text txt;
    [SerializeField] PlayerController player;

    [SerializeField] private int snowflake = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1f, 1f, 1f) + new Vector3(1f, 1f, 0f) * Mathf.Pow(player.GetRadius(), 0.4f);
    }
}
