using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int healthEnemy;
    public int dmgToCastle;
    public int goldAdd;

    public float speed;
    public MainS mainSscript;
   
 
    public Transform startPoint;

    public int wayPnt;
    public GameObject[] waypoints;

    private float lastWaypointSwitchTime;
    public Transform ParentPointShot;
    public float TimeToDisable;

    public Transform start;
    public Transform end;
    public float arriveTime = 3f;
    public float waitTime;
    public float startWaitTime =1;

    public Createenemy cra;
    public TextMesh txtHealth;

    void OnEnable()
    {
        mainSscript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainS>();

       
        cra = GameObject.FindGameObjectWithTag("wayPoint").GetComponent<Createenemy>();
        healthEnemy = cra.HealthEnemy;
        txtHealth.text = healthEnemy.ToString();
        waypoints = mainSscript.waypoints;
    

       Transform parent = transform.parent;
        ParentPointShot = parent;
        waitTime = startWaitTime;
        wayPnt = 0;

    }
    IEnumerator SetDisabled(float TimeToDisable)
    {

        yield return new WaitForSeconds(TimeToDisable);

        gameObject.SetActive(false);
        gameObject.transform.parent = ParentPointShot;
        gameObject.transform.rotation = ParentPointShot.transform.rotation;




    }

  
   
    void Update()
    {
      if (mainSscript.healthCastle <= 0 )

        {
            gameObject.SetActive(false);
            mainSscript.txtGold.text = mainSscript.Gold.ToString();
            healthEnemy = cra.HealthEnemy;
            txtHealth.text = healthEnemy.ToString();
            gameObject.transform.parent = ParentPointShot;
            gameObject.transform.rotation = ParentPointShot.transform.rotation;
            mainSscript.CreateEnemyStop();
     
        }
       else
        {
        
            transform.position = Vector2.MoveTowards(transform.position, waypoints[wayPnt + 1].transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, waypoints[wayPnt + 1].transform.position) < 0.2f)
            {
                if (waitTime <= 0)
                {

                    wayPnt = wayPnt + 1;
                    Rotateobj();
                    waitTime = startWaitTime;

                }
                else
                {
                    waitTime -= Time.deltaTime;

                }
            }
        }




    }

    public void TriggerHealth()
    {
      
        if (healthEnemy <= 0)
        {
            

            gameObject.SetActive(false);
            mainSscript.Gold = mainSscript.Gold + goldAdd;
            mainSscript.txtGold.text = "Gold: " + mainSscript.Gold.ToString();


            healthEnemy = cra.HealthEnemy;
            txtHealth.text = healthEnemy.ToString();
            gameObject.transform.parent = ParentPointShot;
            gameObject.transform.rotation = ParentPointShot.transform.rotation;

            mainSscript.destroyEnemy = mainSscript.destroyEnemy - 1;
            mainSscript.AlldestroyEnemy = mainSscript.AlldestroyEnemy + 1;

         


        }
      
    }

    public void Rotateobj()
    {
        if (waypoints[wayPnt + 1].transform.position.x > waypoints[wayPnt].transform.position.x)

        {

            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (waypoints[wayPnt + 1].transform.position.x < waypoints[wayPnt].transform.position.x)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (waypoints[wayPnt + 1].transform.position.y < waypoints[wayPnt].transform.position.y)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (waypoints[wayPnt + 1].transform.position.y > waypoints[wayPnt].transform.position.y)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.tag == "Castle") {

            mainSscript.healthCastle = mainSscript.healthCastle - dmgToCastle;
            mainSscript.txtHealth.text = "Health: " + mainSscript.healthCastle.ToString();
          
            gameObject.SetActive(false);
            mainSscript.txtGold.text = "Gold: " + mainSscript.Gold.ToString();
            healthEnemy = cra.HealthEnemy; 

            gameObject.transform.parent = ParentPointShot;
            gameObject.transform.rotation = ParentPointShot.transform.rotation;

            mainSscript.destroyEnemy = mainSscript.destroyEnemy - 1;

        }
      }

 

}
