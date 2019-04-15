using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidFloor : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHitbox;
    public GameObject playerHp;
    public GameObject platform;
    public int damage;
    public int iterationMultiplier;
    public float respawnTimer;
    public bool respawn;

    private float platformX;
    private float platformY;
    private float platformZ;
    private bool switchOnce = false;
    private bool damageOnce = false;
    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = player.GetComponent<Rigidbody>();
        platformX = platform.transform.position.x;
        platformY = platform.transform.position.y;
        platformZ = platform.transform.position.z;
    }

    private void OnTriggerEnter(Collider playerHitbox)
    {
        if (playerHitbox.gameObject.tag == "Player")
        {
            if (!damageOnce)
            {
                Vector3 dir = new Vector3 (player.transform.position.x,0, player.transform.position.z) - new Vector3(transform.position.x,0, transform.position.z);
                playerHp.GetComponent<PlayerHealth>().health = playerHp.GetComponent<PlayerHealth>().health - 50;
                rig.AddForce(transform.position - dir * -7000);
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
        if (respawn)
        {
            respawnTimer += Time.deltaTime;
            if (!switchOnce)
            {
                transform.position = new Vector3(transform.position.x, 0.576f - 30, transform.position.z);
                switchOnce = true;
            }
        } 

        if (respawnTimer >= 10)
        {
            transform.position = new Vector3(iterationMultiplier * (Random.Range( 7.8f,23.1f)), 0.576f, Random.Range(-7.3f, 7.8f));
            transform.gameObject.SetActive(true);
            respawnTimer = 0;
            respawn = false;
            switchOnce = false;
        }
    }
}
