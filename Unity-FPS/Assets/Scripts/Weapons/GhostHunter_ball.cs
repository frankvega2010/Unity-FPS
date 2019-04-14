using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHunter_ball : MonoBehaviour
{
    public bool isFired;
    public int damage;
    private float lifespan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFired)
        {
            lifespan += Time.deltaTime;
            if(lifespan >= 5)
            {
                Destroy(gameObject);
                //transform.gameObject.SetActive(false);
                lifespan = 0;
                isFired = false;
            }
        }
    }
}
