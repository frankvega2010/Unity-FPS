using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoScene : MonoBehaviour
{
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void GoToScene()
    {
       SceneManager.LoadScene(SceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
