using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeFromBlackPanel : MonoBehaviour
{
    public GameObject panel;

    public float fadeFromBlackValue = 1;
    public float keepImageTimer;

    private bool keepImage = true;
    private bool fadeFromBlack = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeFromBlack) fadeFromBlackValue -= Time.deltaTime * 0.25f;
        if(keepImage) keepImageTimer += Time.deltaTime;

        if(keepImageTimer >= 1)
        {
            fadeFromBlack = true;
            keepImage = false;
            keepImageTimer = 0;
        }

        if (fadeFromBlackValue <= 0)
        {
            fadeFromBlackValue = 0;
            fadeFromBlack = false;
        }

        panel.GetComponent<Image>().color = new Vector4(0,0,0, fadeFromBlackValue);
    }
}
