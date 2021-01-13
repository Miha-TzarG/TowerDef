using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int healthEnemy;
    public int dmgEnemy;
    public int goldAdd;

   public float speed;
    public MainS mainSscript;

    public CircleCollider2D cc2d;

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

    void OnEnable()
    {
        mainSscript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainS>();

        waypoints = GameObject.FindGameObjectsWithTag("pnt");
       // StartCoroutine(SetDisabled(TimeToDisable));

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

    void Start()
    {
     

    }

    public bool t;
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, waypoints[wayPnt+1].transform.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, waypoints[wayPnt + 1].transform.position) < 0.2f)
        {
            if(waitTime <= 0)
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

    public void TriggerHealth()
    {
      
        if (healthEnemy <= 0)
        {
            //gameObject.transform.position = new Vector2(startPoint.transform.position.x, startPoint.transform.position.y);
           // wayPnt = 0;

            gameObject.SetActive(false);
            mainSscript.Gold = mainSscript.Gold + goldAdd;
            mainSscript.txtGold.text = mainSscript.Gold.ToString();
            healthEnemy = 10;

            gameObject.transform.parent = ParentPointShot;
            gameObject.transform.rotation = ParentPointShot.transform.rotation;
            //  gameObject.SetActive(true);

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
          if (collision.tag == "pnt") {


       /*     if (waypoints[wayPnt + 2].transform.position.x > waypoints[wayPnt + 1].transform.position.x)

            {

                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (waypoints[wayPnt + 2].transform.position.x < waypoints[wayPnt + 1].transform.position.x)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            }

            if (waypoints[wayPnt + 2].transform.position.y < waypoints[wayPnt + 1].transform.position.y)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            if (waypoints[wayPnt + 2].transform.position.y > waypoints[wayPnt + 1].transform.position.y)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
       */
            /* if (transform.position.x > waypoints[0 + wayPnt + 2].transform.position.x-0.05f )

             {

                 gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
             }

          if (transform.position.x < waypoints[0 + wayPnt + 2].transform.position.x - 0.05f)

             {

                 gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
             }

            if (transform.position.y < waypoints[0 + wayPnt + 2].transform.position.y - 0.05f)

            {

                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            }

            if (transform.position.y > waypoints[0 + wayPnt + 2].transform.position.y + 0.05f)

            {

                gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            }*/

            /*
            if (waypoints[0 + wayPnt + 2].transform.position.x < waypoints[0 + wayPnt + 1].transform.position.x)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            }

            if (waypoints[0 + wayPnt + 2].transform.position.y < waypoints[0 + wayPnt + 1].transform.position.y)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            if (waypoints[0 + wayPnt + 2].transform.position.y > waypoints[0 + wayPnt + 1].transform.position.y)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            }*/
            /* {
                 if (gameObject.transform.position == waypoints[wayPnt + 1].transform.position)
                 {
                     Debug.Log("dsa");
                 }*/
            // wayPnt = wayPnt + 1;
            /*wayPnt = collision.;
              if (collision.gameObject.transform.position.x > )
              TriggerHealth();*/
        }
      }

  /*  private void RotateIntoMoveDirection()

    {

        Vector3 startPosition = waypoints[wayPnt].transform.position;
        Vector3 endPosition = waypoints[wayPnt + 1].transform.position;
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
       
        if (gameObject.transform.position.Equals(endPosition))
        {
        //    Debug.Log(waypoints[0+wayPnt+1]);
            

           if (waypoints[0 + wayPnt + 2].transform.position.x > waypoints[0 + wayPnt + 1].transform.position.x)

            {

                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (waypoints[0 + wayPnt + 2].transform.position.x < waypoints[0 + wayPnt + 1].transform.position.x)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            }

            if (waypoints[0 + wayPnt + 2].transform.position.y < waypoints[0 + wayPnt + 1].transform.position.y)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            if (waypoints[0 + wayPnt + 2].transform.position.y > waypoints[0 + wayPnt + 1].transform.position.y)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            }


            wayPnt++;
            lastWaypointSwitchTime = Time.time;
            
        }

    }*/

}
