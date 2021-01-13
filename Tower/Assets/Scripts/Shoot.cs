﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform pool_parent;
    private int pool_element_ID = 0;

    public GameObject prefab;
    public int pool_count = 10;
    public GameObject[] pool_size;

    public Transform point;

    public float TimeSpawn = 0.2f;
    private float nextTime = 0.0f;

    public bool startShoot;

 
   public GameObject target;
 
   // public int dmg;
   // public Towerscript twrScript;

   
    void Start()
    {

     
        pool_size = new GameObject[pool_count];
        for (int i = 0; i < pool_count; i++)
        {
            pool_size[i] = Instantiate(prefab, transform.position, transform.rotation, pool_parent);
            pool_size[i].SetActive(false);
        }

     
    }

    
    void Update()
    {
     
        if (startShoot){
           transform.LookAt(target.transform);
            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeSpawn;
                GameObject obj = pool_parent.GetChild(pool_element_ID).gameObject;
                obj.SetActive(true);
                if (obj.activeInHierarchy)
                {
                    obj.transform.position = new Vector3(point.transform.position.x, point.transform.position.y); // point.tranform.position.x;
                    obj.transform.parent = null;
                }


                pool_element_ID++;
                if (pool_element_ID > pool_parent.childCount - 1) pool_element_ID = 0;
            }
        }
   

    }
    public string nm;

     public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "EnemyOne")
            {
            if (target == null)
            {
                target = collision.gameObject;
                startShoot = true;
            }
         



        }
    }
    //public int a;
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
            }
        

            }
      
    }
 }
  

