using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class UIMatchTimer : MonoBehaviour
{
    public Text matchTime;
    public Text finishText;
    public float matchCountdown;
    public GameObject playerHealth;
    public GameObject panel;
    public RigidbodyFirstPersonController fpc;

    private Vector4 oldPanelColor;
    private float timerLoadScene;
    private UIPlayerHealth UIPlayerHP;
    private Image UIPanel;
    // Start is called before the first frame update
    void Start()
    {
        oldPanelColor = new Vector4(0, 0, 0, 0.7f);
        panel.GetComponent<Image>().color = new Vector4(0, 0, 0, 0);
        UIPlayerHP = playerHealth.GetComponent<UIPlayerHealth>();
        UIPanel = panel.GetComponent<Image>();
    }

    public void playerWin()
    {
        fpc.enabled = false;
        UIPlayerHP.isGameFinished = true;
        finishText.text = "You Won!";
        finishText.color = Color.green;
        timerLoadScene += Time.deltaTime;
        UIPanel.color = oldPanelColor;

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
        if(!UIPlayerHP.isGameFinished) matchCountdown -= Time.deltaTime;

        matchTime.text = "Time Left: " + (int)matchCountdown;

        if (matchCountdown <= 0) playerWin();
    }
}
