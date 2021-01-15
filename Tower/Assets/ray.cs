using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour
{
    public MainS mainscript;
    public Towerscript twrscript;
    public LayerMask NeedLayer;
   
   
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
     {
            
            CastRay();
        }
    }

    public void CastRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 10f, NeedLayer);
     


        if (hit.collider != null)
        {
            if (hit.collider.tag == "TWRUpdateCol") //определяем попадание луча мыши на объект на нужно слое и запускаем меню с апгредом башни
            {
                
                mainscript.nametower = hit.collider.gameObject.name.ToString();
                mainscript.tw = hit.collider.gameObject.GetComponent<Towerscript>();
                twrscript = mainscript.tw;
                mainscript.txt.text = "\n" + "Gold: " + twrscript.priceUpgrade.ToString() + "\n" + "DMG: " + (twrscript.shootScript.Dmg + twrscript.shootScript.UpgradeDmg).ToString();
                mainscript.UpdateMenu();

            }
       
        }
    }
}
