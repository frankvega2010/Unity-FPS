using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;
    public GameObject playerHp;
    public int Ghosthealth = 30;
    public float respawnTimer;
    public float rangeFromX;
    public float rangeToX;
    public float rangeFromZ;
    public float rangeToZ;
    public bool respawn;

    private Vector3 direction;
    private float movementTimer;
    private int whichDirection = 0;
    private bool canChangeDir = true;
    private bool damageOnce = false;
    private bool damagePlayerOnce = false;
    private bool switchOnce = false;
    private Rigidbody rig;
    private Color defaultColor;
    private PlayerPoints playerPoints;
    private GhostHunter_ball GhostHunterProjectile;
    private MeshRenderer ghostModel;
    private UIPlayerHealth playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        playerPoints = PlayerPoints.Get();
        defaultColor = transform.gameObject.GetComponent<MeshRenderer>().material.color;
        GhostHunterProjectile = ball.gameObject.GetComponent<GhostHunter_ball>();
        ghostModel = transform.gameObject.GetComponent<MeshRenderer>();
        rig = player.GetComponent<Rigidbody>();
        playerStatus = playerHp.GetComponent<UIPlayerHealth>();

        movementTimer = 5;
    }

    public void isHit()
    {
        if (!damageOnce)
        {
            Ghosthealth = Ghosthealth - GhostHunterProjectile.damage;
            if (Ghosthealth <= 0)
            {
                respawn = true;
                playerPoints.points = playerPoints.points + 200;
            }
            ghostModel.material.color = Color.red;
            damageOnce = true;
        }
    }

    public void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (!damageOnce)
            {
                Vector3 dir = new Vector3(player.transform.position.x, 0, player.transform.position.z) - 
                              new Vector3(transform.position.x, 0, transform.position.z);

                playerStatus.health = playerStatus.health - 10;
                rig.AddForce(transform.position - dir * -7000);
                damagePlayerOnce = true;
            }
        }
    }

    public void OnCollisionExit(Collision ball)
    {
        if (ball.gameObject.tag == "ball")
        {
            transform.gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;
            damageOnce = false;
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
        movementTimer += Time.deltaTime;
        transform.localPosition += direction * Time.deltaTime * 2;

        if (transform.localPosition.x >= rangeToX)
        {
            movementTimer = 5;
            canChangeDir = false;
            whichDirection = 2;
        } 
        if (transform.localPosition.x <= rangeFromX)
        {
            movementTimer = 5;
            canChangeDir = false;
            whichDirection = 3;
        }
        if (transform.localPosition.z >= rangeToZ)
        {
            movementTimer = 5;
            canChangeDir = false;
            whichDirection = 1;
        }
        if (transform.localPosition.z <= rangeFromZ)
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
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    movementTimer = 0;
                    canChangeDir = true;

                    if (transform.localPosition.z >= 9.4f)
                    {
                        movementTimer = 5;
                        canChangeDir = false;
                        whichDirection = 1;
                    }
                    break;
                case 1:
                    direction = Vector3.back;
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    movementTimer = 0;
                    canChangeDir = true;

                    if (transform.localPosition.z <= -8.6f)
                    {
                        movementTimer = 5;
                        canChangeDir = false;
                        whichDirection = 0;
                    }
                    break;
                case 2:
                    direction = Vector3.left;
                    transform.rotation = Quaternion.Euler(0, 270, 0);
                    movementTimer = 0;
                    canChangeDir = true;

                    if (transform.localPosition.x <= 6.5f)
                    {
                        movementTimer = 5;
                        canChangeDir = false;
                        whichDirection = 3;
                    }
                    break;
                case 3:
                    direction = Vector3.right;
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    movementTimer = 0;
                    canChangeDir = true;

                    if (transform.localPosition.x >= 24.2f)
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
                transform.localPosition = 
                new Vector3(transform.localPosition.x, transform.localPosition.y - 30, transform.localPosition.z);

                switchOnce = true;
            }
        }

        if (respawnTimer >= 10)
        {
            transform.localPosition = 
            new Vector3(Random.Range(rangeFromX, rangeToX), transform.localPosition.y + 30, Random.Range(rangeFromZ, rangeToZ));

            respawnTimer = 0;
            respawn = false;
            switchOnce = false;
            Ghosthealth = 30;
        }
    }
}
