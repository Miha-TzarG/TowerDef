using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(BoxCollider2D))]
public class Towerscript : MonoBehaviour
{

    public int lvl = 1;
 
    public MainS mainscript;


    public Transform goUpdateTWR;
    public TextMesh txtlvl;

    public int priceUpgrade;
  
    public Shoot shootScript;

    public BoxCollider2D cc;
  

    public delegate void ButtonClick();
 

    private void Start()
    {

        mainscript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainS>();

        txtlvl.text = "LVL " + lvl.ToString();
      
     
    }

      

    public void UpgradeTower()
    {

        if (mainscript.Gold - priceUpgrade >= 0)
        {
            lvl = lvl + 1;
        
            shootScript.Dmg = shootScript.Dmg + shootScript.UpgradeDmg;
            mainscript.Gold = mainscript.Gold - priceUpgrade;
            mainscript.txtGold.text = "Gold: " + mainscript.Gold.ToString();
            priceUpgrade = priceUpgrade + 10;
            txtlvl.text = "LVL " + lvl.ToString();
       
        }
     
    }
  

   
}