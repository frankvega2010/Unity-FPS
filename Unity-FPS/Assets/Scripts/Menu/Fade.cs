using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public GameObject image;
    public float time;
    public float time2;

    private bool timeON = false;
    private bool time2ON = false;
    private bool time3ON = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeON) time += Time.deltaTime * 0.3f;
        if (time2ON) time -= Time.deltaTime * 0.3f;
        if (time3ON) time2 += Time.deltaTime;

        if (time2 >= 3)
        {
            timeON = true;
            time2ON = false;
            time2 = 0;
        }

        if (time >= 1)
        {
            time2 += Time.deltaTime;
            time = 1;
            if (time2 >= 3)
            {
                timeON = false;
                time2ON = true;
                time3ON = false;
                time2 = 0;
            } 
        }else if(time <= 0 && !time3ON)
        {
            timeON = false;
            time2ON = false;
            time3ON = true;
        }

        image.GetComponent<RawImage>().color = new Vector4(1, 1, 1, time);
    }
}
