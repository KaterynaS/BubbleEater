using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenExternalLink : MonoBehaviour
{
    //this method will not work in browser
    public void OpenChannel()
    {
        Application.OpenURL("http://kateiana.tech/");
    }
  
}
