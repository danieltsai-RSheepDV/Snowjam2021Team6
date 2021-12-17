using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightScript : MonoBehaviour
{

    // Used as a "tag"
    [SerializeField] private float bossNum = 1;
    string childBaseString = "";

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        childBaseString += "B";
        childBaseString += bossNum.ToString();
        childBaseString += "FB";
    }
    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Player")) {
            // Modify game state, usually the player ->
            for (int i = 1; i < 100; i++) {
                GameObject targetFB = GameObject.Find(childBaseString + i.ToString());
                if (targetFB != null) {
                    targetFB.GetComponent<MeshRenderer>().enabled = true;
                    targetFB.GetComponent<SphereCollider>().enabled = true;
                }
            }
            // Done with object
            // But don't destroy to avoid destroying children
            Destroy(this.gameObject);

        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //}
}
