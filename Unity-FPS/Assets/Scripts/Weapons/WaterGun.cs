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

    private float rayDistance = 5;
    private Color defaultCrosshairColor;
    // Start is called before the first frame update
    void Start()
    {
        defaultCrosshairColor = crosshair.GetComponent<RawImage>().color;
        points = GameObject.Find("PlayerPoints");
        playerHP = GameObject.Find("PlayerHP");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayCastLayer) && playerHP.GetComponent<PlayerHealth>().health > 0)
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            crosshair.GetComponent<RawImage>().color = Color.green;

            switch (layerHitted)
            {
                case "Acid":
                    if (Input.GetMouseButtonDown(0))
                    {
                        hit.transform.gameObject.SetActive(false);
                        points.GetComponent<PlayerPoints>().points = points.GetComponent<PlayerPoints>().points + 100;
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
