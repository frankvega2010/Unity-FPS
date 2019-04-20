using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    public int points;

    private static PlayerPoints instance;
    
    public static PlayerPoints Get()
    {
        return instance;
    }

    public void addPoints(System.String name)
    {
        switch (name)
        {
            case "Acid":
                points = points + 100;
                break;
            case "Ghost":
                points = points + 200;
                break;
            default:
                break;
        }
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
}
