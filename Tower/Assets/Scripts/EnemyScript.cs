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
    // Start is called before the first frame update
    void Start()
    {
        mainSscript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainS>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void TriggerHealth()
    {
       healthEnemy = healthEnemy - 1;
        if (healthEnemy <= 0)
        {
            gameObject.transform.position = new Vector2(startPoint.transform.position.x, startPoint.transform.position.y);
            gameObject.SetActive(false);
            mainSscript.Gold = mainSscript.Gold + goldAdd;
            mainSscript.txtGold.text = mainSscript.Gold.ToString();
            healthEnemy = 10;
            gameObject.SetActive(true);
        }
      
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            TriggerHealth();
        }
    }

    public void otkl()
    {
        cc2d.enabled = false;
    }



   
}
