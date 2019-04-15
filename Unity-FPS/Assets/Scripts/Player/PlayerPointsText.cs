using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPointsText : MonoBehaviour
{
    public Text pointsText;
    public bool isMatchOver = false;

    private GameObject points;
    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.Find("PlayerPoints");
        if(!isMatchOver) points.GetComponent<PlayerPoints>().points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMatchOver) pointsText.text = "Points: " + points.GetComponent<PlayerPoints>().points;
        if (isMatchOver) pointsText.text = points.GetComponent<PlayerPoints>().points.ToString();
    }
}
