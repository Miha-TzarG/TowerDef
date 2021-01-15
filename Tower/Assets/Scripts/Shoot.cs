using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{


    public float TimeDmg= 0.2f;
    private float nextTime = 0.0f;
    public bool startShoot;
    public GameObject target;
    public EnemyScript enemyScript;
    public int Dmg;
    public int UpgradeDmg;
    public Towerscript twsvript;


    
    void Update()
    {
     
        if (startShoot){ //если true то запускаем повреждение. (так же потом можно добавить, что бы запуск снарядов был)
           transform.LookAt(target.transform);
            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeDmg;
                enemyScript.healthEnemy = enemyScript.healthEnemy - Dmg;
                enemyScript.txtHealth.text = enemyScript.healthEnemy.ToString();
                enemyScript.TriggerHealth();
              
            }
         
        }
   

    }
   

     public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "EnemyOne")
            {
            if (target == null)
            {
            
                target = collision.gameObject;
                startShoot = true;
                enemyScript = target.GetComponent<EnemyScript>();
               
            }
         



        }
    }
 
    public void OnTriggerExit2D(Collider2D collision)
     {
        startShoot = false;
       

        target = null;
      

    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "EnemyOne")
        {
          
            if (target == null)
            {
              
                target = collision.gameObject;
                startShoot = true;
                enemyScript = target.GetComponent<EnemyScript>();
            }
        

            }
      
    }
 }
  

