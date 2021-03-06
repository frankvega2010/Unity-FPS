﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostHunter : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;
    public GameObject crosshair;
    public LayerMask rayCastLayer;
    public int ammo = 0;
    public float reloadTimer;
    public bool reloading = false;

    private float rayDistance = 10;
    private Color defaultCrosshairColor;
    private UIPlayerHealth playerHP;
    private PlayerPoints playerPoints;
    private RawImage crosshairImage;
    // Start is called before the first frame update
    void Start()
    {
        ball.GetComponent<MeshRenderer>().enabled = false;
        ball.GetComponent<SphereCollider>().enabled = false;
        playerHP = UIPlayerHealth.Get();
        playerPoints = PlayerPoints.Get();
        crosshairImage = crosshair.GetComponent<RawImage>();
        defaultCrosshairColor = crosshair.GetComponent<RawImage>().color;
        ammo = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(reloading)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= 2)
            {
                ammo = 10;
                reloadTimer = 0;
                reloading = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            reloading = true;
        }

        if (Input.GetMouseButtonDown(0) && ammo > 0 && !reloading)
        {
            ball.SetActive(true);
            GameObject newBall = Instantiate(ball, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Rigidbody newBallRigidbody = newBall.GetComponent<Rigidbody>();
            newBall.GetComponent<MeshRenderer>().enabled = true;
            newBall.GetComponent<SphereCollider>().enabled = true;


            newBall.transform.position = transform.position + Camera.main.transform.forward * 2.0f;
            newBallRigidbody.velocity = Camera.main.transform.forward * 40;
            newBall.GetComponent<GhostHunter_ball>().isFired = true;

            ammo--;
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayCastLayer) && playerHP.health > 0)
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            crosshairImage.color = Color.green;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
            crosshairImage.color = defaultCrosshairColor;
        }
    }
}
