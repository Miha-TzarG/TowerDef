using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createenemy : MonoBehaviour
{

    public Transform pool_parent;
    private int pool_element_ID = 0;

    public GameObject prefab;
    public EnemyScript prefabHealth;
    public int pool_count = 10;
    public GameObject[] pool_size;

    public Transform point;

    public float TimeSpawn = 0.2f;
    private float nextTime = 0.0f;

    public MainS mainscript;

    public int Colvosozdannih;

   public int HealthEnemy;
    public bool create;
   // public int a;
    // Start is called before the first frame update
    void Start()
    {
     
        CreateEnemyingame();

    }

    public void CreateEnemyingame()
    {
      
        HealthEnemy = HealthEnemy + mainscript.numWave;
        pool_count = mainscript.numEnemyinWave;

        pool_size = new GameObject[pool_count];

        for (int i = 0; i < pool_count; i++)
        {

            pool_size[i] = Instantiate(prefab, transform.position, transform.rotation, pool_parent);
            pool_size[i].SetActive(false);
        }
      
    }

    IEnumerator obn()
    {
        yield return new WaitForSeconds(2f);
        pool_count = mainscript.numEnemyinWave;
        pool_size = new GameObject[pool_count];
       
        for (int i = 0; i < pool_count; i++)
        {

            pool_size[i] = Instantiate(prefab, transform.position, transform.rotation, pool_parent);
           
            pool_size[i].SetActive(false);
        }
    }
    
    void Update()
    {
        if (create)
        {
            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeSpawn;
                GameObject obj = pool_parent.GetChild(pool_element_ID).gameObject;
                obj.SetActive(true);
                Colvosozdannih = Colvosozdannih + 1;

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
}
