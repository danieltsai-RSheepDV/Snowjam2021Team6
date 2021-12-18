using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    Text txt;
    [SerializeField] PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string message = "Ball Radius: " + player.GetRadius().ToString("F2") + ".";
        txt.text = message;
    }
}
