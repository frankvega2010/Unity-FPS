using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public GameObject image;

    public float fadeFromBlackValue = 0;
    public float keepImageTimer;
    public float fadeToBlackValue = 1;

    public bool fadeFromBlack = false;
    public bool fadeToBlack = false;
    public bool keepImage = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeFromBlack)
        {
            fadeFromBlackValue += Time.deltaTime * 0.3f;
            image.GetComponent<RawImage>().color = new Vector4(1, 1, 1, fadeFromBlackValue);
        } 

        if (fadeToBlack) 
        {
            fadeToBlackValue -= Time.deltaTime * 0.3f;
            image.GetComponent<RawImage>().color = new Vector4(1, 1, 1, fadeToBlackValue);
        }

        if (keepImage)
        {
            keepImageTimer += Time.deltaTime;
            image.GetComponent<RawImage>().color = new Vector4(1, 1, 1, fadeFromBlackValue);
        } 

        if (keepImageTimer >= 2 && !fadeFromBlack)
        {
            keepImage = false;
            fadeFromBlack = true;
            keepImageTimer = 0;
            fadeToBlackValue = 1;
        }


        if(fadeFromBlackValue >= 1 && fadeFromBlack)
        {
            keepImage = true;
            fadeFromBlackValue = 1;
            if (keepImageTimer >= 2)
            {
                fadeToBlack = true;
                fadeFromBlack = false;
                keepImage = false;
                keepImageTimer = 0;
                fadeToBlackValue = 1;
            }
        }
        else if (fadeToBlackValue <= 0 && !keepImage)
        {
            fadeToBlack = false;
            fadeFromBlack = false;
            keepImage = false;
            fadeFromBlackValue = 0;
            SceneManager.LoadScene("Menu");
        }
    }
}
