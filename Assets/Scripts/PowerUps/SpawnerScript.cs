using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    // Used as a "tag"
    [SerializeField] private float spawnNum = 1;
    string childBaseString = "";

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        childBaseString += "S";
        childBaseString += spawnNum.ToString();
        childBaseString += "B";
    }
    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Player")) {
            // Modify game state, usually the player ->
            for (int i = 1; i < 100; i++) {
                GameObject targetB = GameObject.Find(childBaseString + i.ToString());
                if (targetB != null) {
                    targetB.GetComponent<MeshRenderer>().enabled = true;
                    targetB.GetComponent<BoxCollider>().enabled = true;
                    targetB.GetComponent<Rigidbody>().useGravity = true;
                }
            }
            // Done with object
            Destroy(this.gameObject);

        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //}
}
