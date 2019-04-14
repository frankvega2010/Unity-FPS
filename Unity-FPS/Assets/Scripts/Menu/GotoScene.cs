using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoScene : MonoBehaviour
{
    public string SceneName;

    public void GoToScene()
    {
       SceneManager.LoadScene(SceneName);
    }
}
