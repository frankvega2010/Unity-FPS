using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidFloor : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHitbox;
    public UIPlayerHealth playerHp;
    public GameObject platform;
    public int damage;
    public float respawnTimer;
    public float rangeFromX;
    public float rangeToX;
    public float rangeFromZ;
    public float rangeToZ;
    public float defaultYPos;
    public bool respawn;

    private int force;
    private bool switchOnce = false;
    private bool damageOnce = false;
    private Rigidbody rig;
    private PlayerPoints playerPoints;

    // Start is called before the first frame update
    void Start()
    {
        playerPoints = PlayerPoints.Get();
        playerHp = UIPlayerHealth.Get();
        rig = player.GetComponent<Rigidbody>();
        force = -7000;
    }

    public void isHit()
    {
        respawn = true;
        playerPoints.points = playerPoints.points + 100;
    }

    private void OnTriggerEnter(Collider playerHitbox)
    {
        if (playerHitbox.gameObject.tag == "Player")
        {
            if (!damageOnce)
            {
                Vector3 dir = new Vector3 (player.transform.position.x,0, player.transform.position.z) - 
                              new Vector3(transform.position.x,0, transform.position.z);

                playerHp.health = playerHp.health - damage;
                rig.AddForce(transform.position - dir * force);
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
                transform.localPosition = 
                new Vector3(transform.localPosition.x, transform.localPosition.y - 30, transform.localPosition.z);

                switchOnce = true;
            }
        } 

        if (respawnTimer >= 10)
        {
            transform.localPosition = 
            new Vector3(Random.Range( rangeFromX,rangeToX), defaultYPos, Random.Range(rangeFromZ, rangeToZ));

            transform.gameObject.SetActive(true);
            respawnTimer = 0;
            respawn = false;
            switchOnce = false;
        }
    }
}
