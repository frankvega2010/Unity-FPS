using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveWeapon : MonoBehaviour
{
    public GameObject waterGunModel;
    public GameObject waterGunGO;
    public GameObject ghostHunterModel;
    public GameObject ghostHunterGO;
    public Text currentWeaponText;
    public Text currentAmmoText;

    private WaterGun waterGun;
    private GhostHunter ghostHunter;
    private bool ghostHunterActive = false;
    private bool waterGunActive = false;
    private Color defaultColor;
    private Color reloadColor;

    // Start is called before the first frame update
    void Start()
    {
        waterGun = waterGunGO.GetComponent<WaterGun>();
        ghostHunter = ghostHunterGO.GetComponent<GhostHunter>();
        currentWeaponText.text = "Current Weapon: Water Gun 2.0";
        currentAmmoText.text = "Ammo: " + waterGun.GetComponent<WaterGun>().ammo;
        defaultColor = currentAmmoText.color;
        reloadColor = new Vector4(1f, 0.2f, 0.2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(waterGunActive)
        {
            if (waterGun.ammo > 0)
            {
                if (!waterGun.reloading)
                {
                    currentAmmoText.text = "Ammo: " + waterGun.ammo;
                    currentAmmoText.color = defaultColor;
                }
                else
                {
                    currentAmmoText.text = "Ammo: RELOADING..";
                    currentAmmoText.color = Color.green;
                }
            } 
            else if (waterGun.ammo <= 0)
            {
                if (!waterGun.reloading)
                {
                    currentAmmoText.text = "Ammo: RELOAD!";
                    currentAmmoText.color = reloadColor;
                }
                else
                {
                    currentAmmoText.text = "Ammo: RELOADING..";
                    currentAmmoText.color = Color.green;
                }
            }
        }
        else if(ghostHunterActive)
        {
            if (ghostHunter.ammo > 0)
            {
                if (!ghostHunter.reloading)
                {
                    currentAmmoText.text = "Ammo: " + ghostHunter.ammo;
                    currentAmmoText.color = defaultColor;
                }
                else
                {
                    currentAmmoText.text = "Ammo: RELOADING..";
                    currentAmmoText.color = Color.green;
                } 
            } 
            else if (ghostHunter.ammo <= 0)
            {
                if (!ghostHunter.reloading)
                {
                    currentAmmoText.text = "Ammo: RELOAD!";
                    currentAmmoText.color = reloadColor;
                }
                else
                {
                    currentAmmoText.text = "Ammo: RELOADING..";
                    currentAmmoText.color = Color.green;
                } 
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            waterGunActive = true;
            ghostHunterActive = false;
            waterGunGO.SetActive(true);
            waterGunModel.SetActive(true);
            ghostHunterGO.SetActive(false);
            ghostHunterModel.SetActive(false);
            currentWeaponText.text = "Current Weapon: Water Gun 2.0";
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            waterGunActive = false;
            ghostHunterActive = true;
            waterGunGO.SetActive(false);
            waterGunModel.SetActive(false);
            ghostHunterGO.SetActive(true);
            ghostHunterModel.SetActive(true);
            currentWeaponText.text = "Current Weapon: Ghost Hunter X";
            
        }
    }
}
