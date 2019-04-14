using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHunter : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ball.GetComponent<MeshRenderer>().enabled = false;
        ball.GetComponent<SphereCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ball.SetActive(true);
            GameObject newBall = Instantiate(ball, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Rigidbody newBallRigidbody = newBall.GetComponent<Rigidbody>();
            newBall.GetComponent<MeshRenderer>().enabled = true;
            newBall.GetComponent<SphereCollider>().enabled = true;


            newBall.transform.position = transform.position + Camera.main.transform.forward * 2.0f;
            newBallRigidbody.velocity = Camera.main.transform.forward * 40;
            newBall.GetComponent<GhostHunter_ball>().isFired = true;
            //rig.AddForce(transform.position - dir * -7000);
            //newBallRigidbody.AddForce(dir * 5, ForceMode.Impulse);
            //hit.transform.gameObject.GetComponent<AcidFloor>().respawn = true;
            //points.GetComponent<PlayerPoints>().points = points.GetComponent<PlayerPoints>().points + 100;
            //hit.transform.gameObject.SetActive(false);
        }
    }
}
