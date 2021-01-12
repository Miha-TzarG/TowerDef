using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTowers : MonoBehaviour
{

    public int upgardeLvl;
    public Towerscript twr1;
    public MainS ms;
    
    public void OnMouseUp()
    {
        ms = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainS>();
       
        twr1 = ms.tw;
        twr1.UpgradeTower();
    }

}
