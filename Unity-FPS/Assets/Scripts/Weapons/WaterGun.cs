using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterGun : MonoBehaviour
{
    public GameObject crosshair;
    private GameObject points;
    private GameObject playerHP;
    public LayerMask rayCastLayer;
    public int ammo = 5;
    public float reloadTimer;
    public bool reloading = false;

    private float rayDistance = 5;
    private Color defaultCrosshairColor;
    // Start is called before the first frame update
    void Start()
    {
        defaultCrosshairColor = crosshair.GetComponent<RawImage>().color;
        points = GameObject.Find("PlayerPoints");
        playerHP = GameObject.Find("PlayerHP");
        ammo = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= 1.5f)
            {
                ammo = 5;
                reloadTimer = 0;
                reloading = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            reloading = true;
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayCastLayer) && playerHP.GetComponent<PlayerHealth>().health > 0)
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            crosshair.GetComponent<RawImage>().color = Color.green;

            switch (layerHitted)
            {
                case "Acid":
                    if (Input.GetMouseButtonDown(0) && ammo > 0 && !reloading)
                    {
                        hit.transform.gameObject.GetComponent<AcidFloor>().respawn = true;
                        points.GetComponent<PlayerPoints>().points = points.GetComponent<PlayerPoints>().points + 100;
                        ammo--;
                    } 
                    break;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
            crosshair.GetComponent<RawImage>().color = defaultCrosshairColor;
        }
    }
}
