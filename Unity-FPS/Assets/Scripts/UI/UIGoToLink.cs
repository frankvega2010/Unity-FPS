using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGoToLink : MonoBehaviour
{
    public string url;
    public void GotoWebsite()
    {
        Application.OpenURL(url);
    }
}
