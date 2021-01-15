using System;

using UnityEngine;

public class Cam : MonoBehaviour
{
    void Start()
    {
        float aspect = (float)Screen.width / (float)Screen.height;
      
    
        aspect = (float)Math.Round(aspect, 2);
      
        if (aspect == 1.6f)
            GetComponent<Camera>().orthographicSize = 5.6f;                    //16:10
        else if (aspect == 1.78f)
            GetComponent<Camera>().orthographicSize = 5.04f;    //16:9
        else if (aspect == 1.5f)
            GetComponent<Camera>().orthographicSize = 6.06f;                  //3:2
        else if (aspect == 1.33f)
            GetComponent<Camera>().orthographicSize = 6.71f;                  //4:3
        else if (aspect == 1.67f)
            GetComponent<Camera>().orthographicSize = 6.6f;                  //5:3
        else if (aspect == 1.25f)
            GetComponent<Camera>().orthographicSize = 7.08f;                  //5:4
     
    }

  
}
