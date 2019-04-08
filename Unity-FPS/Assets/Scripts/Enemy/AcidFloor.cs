using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidFloor : MonoBehaviour
{
    //public GameObject acid;
    public GameObject player;
    public GameObject playerHitbox;
    public GameObject playerHp;
    public int damage;

    private bool damageOnce = false;
    //private Rigidbody playerRig;
    // Start is called before the first frame update
    void Start()
    {
        
        //playerRig = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider playerHitbox)
    {
        //Debug.Log("piso");

        if (playerHitbox.gameObject.tag == "Player")
        {
            if (!damageOnce)
            {
                playerHp.GetComponent<PlayerHealth>().health = playerHp.GetComponent<PlayerHealth>().health - 50;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = new Vector3(50, 50, 50);
                player.GetComponent<CharacterController>().enabled = true;
                //playerRig.AddForce(Vector3.back * 2, ForceMode.Impulse);
                damageOnce = true;
            }
        }
    }

    private void OnTriggerExit(Collider playerHitbox)
    {
        if (playerHitbox.gameObject.tag == "Player")
        {
            if (damageOnce)
            {
                damageOnce = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
