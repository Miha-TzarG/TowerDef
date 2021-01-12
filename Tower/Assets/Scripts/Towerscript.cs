using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Towerscript : MonoBehaviour
{

    public int lvl=1;
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
        
        goUpdateTWR.transform.position = new Vector2(this.transform.position.x+1, this.transform.position.y); // Располагаем кнопку UpdateTWR рядом с башней
        
        txtpriceUpgrade = GameObject.FindGameObjectWithTag("PriceUpgradeTWR").GetComponent<TextMesh>(); // Находим Textmesh, на котором отображется цена апгрейда
        txtpriceUpgrade.text = priceUpgrade.ToString(); //присваеиваем значение стоимости апгрейда
       
        mainscript.nametower = gameObject.name.ToString();
        mainscript.tw = this.GetComponent<Towerscript>();


      // nameObject = gameObject.name.ToString();
       // Debug.Log(gameObject.name);
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
            txtpriceUpgrade.text = priceUpgrade.ToString();
        }
        else{

        }
    }

  
}
