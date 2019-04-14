using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public Text healthText;
    public Text finishText;
    public GameObject panel;
    public FirstPersonController fpc;

    private Vector4 oldPanelColor;
    private bool isGameFinished = false;
    private float timerDeath = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        oldPanelColor = panel.GetComponent<Image>().color;
        panel.GetComponent<Image>().color = new Vector4(0, 0, 0, 0);
    }

    private void playerDeath()
    {
        fpc.GetComponent<FirstPersonController>().enabled = false;
        isGameFinished = true;
        finishText.text = "You Lost";
        timerDeath += Time.deltaTime;
        panel.GetComponent<Image>().color = oldPanelColor;

        if (timerDeath >= 3)
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
        healthText.text = "HP: " + health;
        if (!isGameFinished) finishText.text = "";

        if (health <= 0) playerDeath();
    }
}
