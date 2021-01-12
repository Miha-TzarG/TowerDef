using System;
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

    public float dist;
   public GameObject target;
    public GameObject[] masstarget;
    public int enemycount;
    // Start is called before the first frame update
    void Start()
    {

       // target = collision.gameObject;
        pool_size = new GameObject[pool_count];
        for (int i = 0; i < pool_count; i++)
        {
            pool_size[i] = Instantiate(prefab, transform.position, transform.rotation, pool_parent);
            pool_size[i].SetActive(false);
        }

        masstarget = GameObject.FindGameObjectsWithTag("EnemyOne");


        for (int i = 0; i < masstarget.Length; i++)
        {
            enemycount = masstarget.Length;
            masstarget[0 + a].GetComponent<BoxCollider2D>().enabled = true;

        }


        /*  target = new GameObject[enemycount];
          for (int i = 0; i < enemycount; i++)
          {
              target[i] = FindGameObjectWithTag("EnemiOne"); // Instantiate(prefab, transform.position, transform.rotation, pool_parent);
                                                                                                     // target[i].SetActive(false);
          }*/
        //target[enemycount] = collision.gameObject;
        //   target = GetComponent<Transform>(); ;
        // target = GameObject.Find("EnemiOne");
    }

    private GameObject FindGameObjectsWithTag(string v)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 LookAtPoint = new Vector2(target.transform.position.x, target.transform.position.y);
        // transform.LookAt(new Vector3(0, LookAtPoint.y, LookAtPoint.x));

        // transform.LookAt(new Vector2(target.transform.position.x, target.transform.position.y));


        /*if (startShoot)
        {*/
      //  target =  GameObject.FindGameObjectWithTag("EnemyOne");
        dist = Vector3.Distance(masstarget[a].transform.position, transform.position);
       if(dist < 4)
        {
            startShoot = true;
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
        else
        {
            startShoot = false;
            target = GameObject.FindGameObjectWithTag("EnemyOne");
        }

    }
    public string nm;
    /*   public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "EnemyOne")
            {

              enemycount = enemycount + 1;
              masstarget = new GameObject[enemycount];


                 masstarget[enemycount-1] = collision.gameObject;
              Debug.Log(masstarget);
              //enemycount = enemycount + 1;

              // enemycount = enemycount + 1;





          }
    }*/
    public int a;
    public void OnTriggerExit2D(Collider2D collision)
     {
        a = a + 1;
        //  startShoot = false;
         masstarget[a].GetComponent<BoxCollider2D>().enabled = true;
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "EnemyOne")
        {
          //  enemycount = enemycount + 1;

           // for (int i = 0; i < pool_count; i++)
           // {
                masstarget = GameObject.FindGameObjectsWithTag("EnemyOne");
           
            
            for (int i = 0; i < masstarget.Length; i++)
              {
                enemycount = masstarget.Length;
                masstarget[0+a].GetComponent<BoxCollider2D>().enabled = true;

            }
                //  nm = collision.name.ToString();
                // target = new GameObject[enemycount];
                //enemycount = enemycount + 1;

                target = collision.gameObject;
            //  target = GameObject.Find("EnemiOne");

            //Debug.Log(nm);

            startShoot = true;
        }
        if (collision.tag != "EnemyOne")
        {
        //    startShoot = false;
        }
    }
 }
  

