using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Towerscript : MonoBehaviour
{

    public int lvl = 1;
 
    public MainS mainscript;


    public Transform goUpdateTWR;
    public TextMesh txtlvl;

    public int priceUpgrade;
  
    public Shoot shootScript;


   

    private void Start()
    {
       
        txtlvl.text = "LVL " + lvl.ToString(); 
       
    }
    public void OnMouseDown()
    {
    }

    public void OnMouseUp()
    {
     
        mainscript.nametower = gameObject.name.ToString();
        mainscript.tw = this.GetComponent<Towerscript>();

        mainscript.UpdateMenu();

        mainscript.txt.text = "\n" + "Gold: " + priceUpgrade.ToString() + "\n" + "DMG: " + (shootScript.Dmg + shootScript.UpgradeDmg).ToString();
      



    }


    public void UpgradeTower()
    {

        if (mainscript.Gold - priceUpgrade >= 0)
        {
            lvl = lvl + 1;
        
            shootScript.Dmg = shootScript.Dmg + shootScript.UpgradeDmg;
            mainscript.Gold = mainscript.Gold - priceUpgrade;
            mainscript.txtGold.text = mainscript.Gold.ToString();
            priceUpgrade = priceUpgrade + 10;
            txtlvl.text = "LVL " + lvl.ToString();
       
        }
        else
        {

        }
    }
  

   
}