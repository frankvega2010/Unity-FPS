using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MatchTimer : MonoBehaviour
{
    public Text matchTime;
    public float matchCountdown;
    public GameObject playerHealth;
    private float timerLoadScene;

    public Text finishText;
    public GameObject panel;
    public RigidbodyFirstPersonController fpc;

    private Vector4 oldPanelColor;

    // Start is called before the first frame update
    void Start()
    {
        oldPanelColor = new Vector4(0, 0, 0, 0.7f);
        panel.GetComponent<Image>().color = new Vector4(0, 0, 0, 0);
    }

    public void playerWin()
    {
        fpc.GetComponent<RigidbodyFirstPersonController>().enabled = false;
        playerHealth.GetComponent<PlayerHealth>().isGameFinished = true;
        finishText.text = "You Won!";
        finishText.color = Color.green;
        timerLoadScene += Time.deltaTime;
        panel.GetComponent<Image>().color = oldPanelColor;

        if (timerLoadScene >= 3)
        {
            SceneManager.LoadScene("Gameplay_End");
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerHealth.GetComponent<PlayerHealth>().isGameFinished) matchCountdown -= Time.deltaTime;

        matchTime.text = "Time Left: " + (int)matchCountdown;

        if (matchCountdown <= 0) playerWin();
    }
}
