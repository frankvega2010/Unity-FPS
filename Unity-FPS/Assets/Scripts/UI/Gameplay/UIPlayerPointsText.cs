using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerPointsText : MonoBehaviour
{
    public Text pointsText;
    public bool isMatchOver = false;
    private PlayerPoints playerPoints;

    // Start is called before the first frame update
    void Start()
    {
        playerPoints = PlayerPoints.Get();
        if (!isMatchOver) playerPoints.points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMatchOver) pointsText.text = "Points: " + playerPoints.points;
        if (isMatchOver) pointsText.text = playerPoints.points.ToString();
    }
}
