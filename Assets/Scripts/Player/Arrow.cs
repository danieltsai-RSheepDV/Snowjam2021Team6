using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField] private GameObject snowball;
    [SerializeField] private Camera cam;

    private PlayerController playerController;
    private SpriteRenderer sp;
    
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        playerController = snowball.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.CanShoot())
        {
            transform.position = snowball.transform.position;
            transform.eulerAngles = new Vector3(-90, cam.transform.eulerAngles.y + 180, 0);
            transform.localScale = new Vector3(playerController.GetRadius(),playerController.GetRadius(), 1f);
            sp.size = new Vector2(1, playerController.GetIsAiming() ? playerController.GetPower() / 10f : 2f);
            sp.enabled = true;
        }
        else
        {
            sp.enabled = false;
        }
    }
}
