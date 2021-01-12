using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainS : MonoBehaviour
{
    public string nametower;
    public Towerscript tw;

    public int Gold;
    public TextMesh txtGold;
    // Start is called before the first frame update
    void Start()
    {
        txtGold.text = Gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
