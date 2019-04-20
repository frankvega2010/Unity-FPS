using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeFromBlackPanel : MonoBehaviour
{
    public GameObject panel;

    public float fadeFromBlackValue = 1;
    public float keepImageTimer;

    private bool keepImage = true;
    private bool fadeFromBlack = false;

    private Image UIPanel;

    void Start()
    {
        UIPanel = panel.GetComponent<Image>();
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

        UIPanel.color = new Vector4(0,0,0, fadeFromBlackValue);
    }
}
