using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGotoScene : MonoBehaviour
{
    public string SceneName;

    public void GoToScene()
    {
       SceneManager.LoadScene(SceneName);
    }
}