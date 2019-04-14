using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToLink : MonoBehaviour
{
    public string url;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GotoWebsite()
    {
        Application.OpenURL(url);
        Debug.Log("going to " + url);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
