using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    public GameObject waterGun_prop;
    public GameObject waterGun;
    public GameObject ghostHunter_prop;
    public GameObject ghostHunter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            waterGun.SetActive(true);
            waterGun_prop.SetActive(true);
            ghostHunter.SetActive(false);
            ghostHunter_prop.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            waterGun.SetActive(false);
            waterGun_prop.SetActive(false);
            ghostHunter.SetActive(true);
            ghostHunter_prop.SetActive(true);
        }
    }
}
