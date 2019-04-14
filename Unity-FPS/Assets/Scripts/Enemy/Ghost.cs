using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float localRotY;
    public GameObject ball;
    public GameObject player;
    public GameObject playerHp;
    public int iterationMultiplier;
    public int Ghosthealth = 30;
    public bool respawn;
    public float respawnTimer;
    private float movementTimer;
    private Vector3 direction;
    private bool canChangeDir = true;
    private bool damageOnce = false;
    private bool damagePlayerOnce = false;
    private bool switchOnce = false;
    private int whichDirection = 0;
    private GameObject points;
    private Rigidbody rig;
    


    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.Find("PlayerPoints");
        movementTimer = 5;
        rig = player.GetComponent<Rigidbody>();
    }

    public void OnCollisionEnter(Collision ball)
    {
        //Debug.Log("touched");
        if(ball.gameObject.tag == "ball")
        {
            if (!damageOnce)
            {
                Ghosthealth = Ghosthealth - ball.gameObject.GetComponent<GhostHunter_ball>().damage;
                if (Ghosthealth <= 0)
                {
                    //transform.gameObject.SetActive(false);
                    respawn = true;
                    points.GetComponent<PlayerPoints>().points = points.GetComponent<PlayerPoints>().points + 200;
                }
                transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                damageOnce = true;
            }
        }

        if (player.gameObject.tag == "Player")
        {
            if (!damageOnce)
            {
                Vector3 dir = new Vector3(player.transform.position.x, 0, player.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z);
                playerHp.GetComponent<PlayerHealth>().health = playerHp.GetComponent<PlayerHealth>().health - 10;
                rig.AddForce(transform.position - dir * -7000);
                damagePlayerOnce = true;
            }
        }
    }

    public void OnCollisionExit(Collision ball)
    {
        if (ball.gameObject.tag == "ball")
        {
            transform.gameObject.GetComponent<MeshRenderer>().material.color = new Vector4(0.2f, 1, 0.2f, 0.65f);
            damageOnce = false;
            //Debug.Log("touched");
        }

        if (player.gameObject.tag == "Player")
        {
            if (damagePlayerOnce)
            {
                damagePlayerOnce = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        localRotY = (transform.localEulerAngles.y + 360) % 360;

        movementTimer += Time.deltaTime;
        transform.position += direction * Time.deltaTime * 2;

        //transform.position = new Vector3(iterationMultiplier * (Random.Range( 7.8f,23.1f)), 0.576f, Random.Range(-7.3f, 7.8f));
        if (transform.position.x >= 24.2f * iterationMultiplier)
        {
            movementTimer = 5;
            canChangeDir = false;
            whichDirection = 2;
        } 
        if (transform.position.x <= 6.5f * iterationMultiplier)
        {
            movementTimer = 5;
            canChangeDir = false;
            whichDirection = 3;
        }
        if (transform.position.z >= 9.4f)
        {
            movementTimer = 5;
            canChangeDir = false;
            whichDirection = 1;
        }
        if (transform.position.z <= -8.6f)
        {
            movementTimer = 5;
            canChangeDir = false;
            whichDirection = 0;
        }

        if (movementTimer >= 5)
        {
            if (canChangeDir) whichDirection = Random.Range(0, 4);

            switch (whichDirection)
            {
                case 0:
                    direction = Vector3.forward;
                    transform.rotation = Quaternion.Euler(0, 270, 0);
                   // transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                    movementTimer = 0;
                    canChangeDir = true;

                    if (transform.position.z >= 9.4f)
                    {
                        movementTimer = 5;
                        canChangeDir = false;
                        whichDirection = 1;
                    }
                    break;
                case 1:
                    direction = Vector3.back;
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    //transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                    movementTimer = 0;
                    canChangeDir = true;

                    if (transform.position.z <= -8.6f)
                    {
                        movementTimer = 5;
                        canChangeDir = false;
                        whichDirection = 0;
                    }
                    break;
                case 2:
                    direction = Vector3.left;
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    //transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
                    movementTimer = 0;
                    canChangeDir = true;

                    if (transform.position.x <= 6.5f * iterationMultiplier)
                    {
                        movementTimer = 5;
                        canChangeDir = false;
                        whichDirection = 3;
                    }
                    break;
                case 3:
                    direction = Vector3.right;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    //transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                    movementTimer = 0;
                    canChangeDir = true;

                    if (transform.position.x >= 24.2f * iterationMultiplier)
                    {
                        movementTimer = 5;
                        canChangeDir = false;
                        whichDirection = 2;
                    }
                    break;
                default:
                    break;
            }
        }

        if (respawn)
        {
            respawnTimer += Time.deltaTime;
            if (!switchOnce)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 30, transform.position.z);
                switchOnce = true;
            }
        }

        if (respawnTimer >= 10)
        {
            transform.position = new Vector3(iterationMultiplier * (Random.Range(6.5f, 24.2f)), transform.position.y + 30, Random.Range(-8.6f, 9.4f));
            //transform.gameObject.SetActive(true);
            respawnTimer = 0;
            respawn = false;
            switchOnce = false;
            Ghosthealth = 30;
        }
    }
}
