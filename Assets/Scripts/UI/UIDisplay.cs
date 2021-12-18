using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    float radius;
    Text txt;
    [SerializeField] PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        radius = 0f;
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        radius = player.GetRadius();
        txt.text = "Ball Radius: " + radius;
    }
}
