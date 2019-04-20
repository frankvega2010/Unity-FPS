using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterGun : MonoBehaviour
{
    public GameObject crosshair;
    public LayerMask rayCastLayer;
    public int ammo = 5;
    public float reloadTimer;
    public bool reloading = false;

    private float rayDistance = 5;
    private UIPlayerHealth playerHP;
    private Color defaultCrosshairColor;
    private RawImage crosshairImage;
    // Start is called before the first frame update
    void Start()
    {
        defaultCrosshairColor = crosshair.GetComponent<RawImage>().color;
        playerHP = UIPlayerHealth.Get();
        crosshairImage = crosshair.GetComponent<RawImage>();
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

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayCastLayer) && playerHP.health > 0)
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            crosshairImage.color = Color.green;

            AcidFloor acidEnemy = hit.transform.gameObject.GetComponent<AcidFloor>();

            switch (layerHitted)
            {
                case "Acid":
                    if (Input.GetMouseButtonDown(0) && ammo > 0 && !reloading)
                    {
                        acidEnemy.isHit();
                        ammo--;
                    }
                    break;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
            crosshairImage.color = defaultCrosshairColor;
        }
    }
}
