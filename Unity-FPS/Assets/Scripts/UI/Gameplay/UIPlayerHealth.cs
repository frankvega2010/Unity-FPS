using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityStandardAssets.Characters.FirstPerson;

public class UIPlayerHealth : MonoBehaviour
{
    public int initialHealth;
    public int health;
    public Text healthText;
    public Text finishText;
    public GameObject panel;
    public RigidbodyFirstPersonController fpc;
    public bool isGameFinished = false;

    private Vector4 oldPanelColor;
    private float timerDeath = 0.0f;
    private Image UIPanel;

    private static UIPlayerHealth instance;

    public static UIPlayerHealth Get()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        oldPanelColor = panel.GetComponent<Image>().color;
        UIPanel = panel.GetComponent<Image>();
        UIPanel.color = new Vector4(0, 0, 0, 0);
    }

    private void playerDeath()
    {
        fpc.enabled = false;
        isGameFinished = true;
        finishText.color = Color.red;
        finishText.text = "You Lost";
        timerDeath += Time.deltaTime;
        UIPanel.color = oldPanelColor;

        if (timerDeath >= 3)
        {
            SceneManager.LoadScene("Gameplay_End");
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            health = initialHealth;
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
