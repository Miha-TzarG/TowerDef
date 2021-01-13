using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Towerscript : MonoBehaviour
{

    public int lvl = 1;
    public int dmg;
    public string nameObject;

    public MainS mainscript;

    public Transform goUpdateTWR;

    public TextMesh txtlvl;

    public int priceUpgrade;
    public TextMesh txtpriceUpgrade;

    private void Start()
    {

        txtlvl.text = "LVL " + lvl.ToString(); // Show Tower level
    }
    public void OnMouseDown()
    {
        // mainscript = GetComponent<MainS>();
        //    Debug.Log("Down");
    }

    public void OnMouseUp()
    {
        goUpdateTWR = GameObject.FindGameObjectWithTag("UpdateTower").GetComponent<Transform>(); //Находим кнопку UpdateTWR

        goUpdateTWR.transform.position = new Vector2(8, -0.65f); // Располагаем кнопку UpdateTWR рядом с башней

        txtpriceUpgrade = GameObject.FindGameObjectWithTag("PriceUpgradeTWR").GetComponent<TextMesh>(); // Находим Textmesh, на котором отображется цена апгрейда
        txtpriceUpgrade.text = "\n" + "Gold: " + priceUpgrade.ToString() + "\n" + "DMG: " + dmg.ToString(); //присваеиваем значение стоимости апгрейда

        mainscript.nametower = gameObject.name.ToString();
        mainscript.tw = this.GetComponent<Towerscript>();

     
    }


    public void UpgradeTower()
    {

        if (mainscript.Gold - priceUpgrade >= 0)
        {
            lvl = lvl + 1;
            dmg = dmg + 5;
            mainscript.Gold = mainscript.Gold - priceUpgrade;
            mainscript.txtGold.text = mainscript.Gold.ToString();
            priceUpgrade = priceUpgrade + 10;
            txtlvl.text = "LVL " + lvl.ToString();
            txtpriceUpgrade.text = "\n" + "Gold: " + priceUpgrade.ToString() + "\n"+"DMG: " + dmg.ToString(); ;
            goUpdateTWR.transform.position = new Vector2(0.8f, -8.28f);
        }
        else
        {

        }
    }
  

   
}