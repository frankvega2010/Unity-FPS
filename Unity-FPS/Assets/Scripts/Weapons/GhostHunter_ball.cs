using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHunter_ball : MonoBehaviour
{
    public int damage;
    public bool isFired;
    private float lifespan;

    // Update is called once per frame
    void Update()
    {
        if(isFired)
        {
            lifespan += Time.deltaTime;
            if(lifespan >= 5)
            {
                Destroy(gameObject);
                lifespan = 0;
                isFired = false;
            }
        }
    }

    public void OnCollisionEnter(Collision ghost)
    {
        Ghost ghostEnemy = ghost.gameObject.GetComponent<Ghost>();
        if (ghost.gameObject.tag == "Ghost")
        {
            ghostEnemy.isHit();
        }
    }
}
