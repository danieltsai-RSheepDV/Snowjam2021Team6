using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FattenPowerUpScript : MonoBehaviour
{

    [SerializeField] private int id;
    // Touch = collect
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            // Modify game state, usually the player ->
            other.GetComponentInParent<PlayerController>().AddRadius(5f);
            other.transform.parent.GetComponentInChildren<SnowballSound>().PlayPowerUpSFX();
            GameObject label = GameObject.Find("FattenPowerUpText" + id.ToString());
            if (label != null) {
                Destroy(label);
            }
            // Done with object
            Destroy(this.gameObject);
        }
    }
}
