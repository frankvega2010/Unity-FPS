using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveWeapon : MonoBehaviour
{
    public GameObject waterGun_prop;
    public GameObject waterGun;
    public GameObject ghostHunter_prop;
    public GameObject ghostHunter;
    public Text currentWeaponText;
    public Text currentAmmoText;

    private bool ghostHunterActive = false;
    private bool waterGunActive = false;
    private bool ghostHunterNeedsReload = false;
    private bool waterGunNeedsReload = false;

    // Start is called before the first frame update
    void Start()
    {
        currentWeaponText.text = "Current Weapon: Water Gun 2.0";
        currentAmmoText.text = "Ammo: " + waterGun.GetComponent<WaterGun>().ammo;
    }

    // Update is called once per frame
    void Update()
    {
        if(waterGunActive)
        {
            if (waterGun.GetComponent<WaterGun>().ammo > 0)
            {
                if (!waterGun.GetComponent<WaterGun>().reloading) currentAmmoText.text = "Ammo: " + waterGun.GetComponent<WaterGun>().ammo;
                else currentAmmoText.text = "Ammo: RELOADING..";
            } 
            else if (waterGun.GetComponent<WaterGun>().ammo <= 0)
            {
                if(!waterGun.GetComponent<WaterGun>().reloading) currentAmmoText.text = "Ammo: RELOAD!";
                else currentAmmoText.text = "Ammo: RELOADING..";
            }
        }
        else if(ghostHunterActive)
        {
            if (ghostHunter.GetComponent<GhostHunter>().ammo > 0)
            {
                if (!ghostHunter.GetComponent<GhostHunter>().reloading) currentAmmoText.text = "Ammo: " + ghostHunter.GetComponent<GhostHunter>().ammo;
                else currentAmmoText.text = "Ammo: RELOADING..";
            } 
            else if (ghostHunter.GetComponent<GhostHunter>().ammo <= 0)
            {
                if (!ghostHunter.GetComponent<GhostHunter>().reloading) currentAmmoText.text = "Ammo: RELOAD!";
                else currentAmmoText.text = "Ammo: RELOADING..";
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            waterGunActive = true;
            ghostHunterActive = false;
            waterGun.SetActive(true);
            waterGun_prop.SetActive(true);
            ghostHunter.SetActive(false);
            ghostHunter_prop.SetActive(false);
            currentWeaponText.text = "Current Weapon: Water Gun 2.0";
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            waterGunActive = false;
            ghostHunterActive = true;
            waterGun.SetActive(false);
            waterGun_prop.SetActive(false);
            ghostHunter.SetActive(true);
            ghostHunter_prop.SetActive(true);
            currentWeaponText.text = "Current Weapon: Ghost Hunter X";
            
        }
    }
}
