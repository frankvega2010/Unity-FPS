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

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider playerHitbox)
    {
        //Debug.Log("piso");

        if (playerHitbox.gameObject.tag == "Player")
        {
            if (!damageOnce)
            {
                Vector3 dir = new Vector3 (player.transform.position.x,0, player.transform.position.z) - new Vector3(transform.position.x,0, transform.position.z);
                playerHp.GetComponent<PlayerHealth>().health = playerHp.GetComponent<PlayerHealth>().health - 50;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = transform.position - dir * -2f;
                player.GetComponent<CharacterController>().enabled = true;
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
