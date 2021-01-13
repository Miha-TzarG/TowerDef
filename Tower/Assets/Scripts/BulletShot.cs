using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public float speedBullet;

    public float TimeToDisable;
    public Transform ParentPointShot;
    public Shoot Parentshoot;
    public Towerscript twrScript;

    public string tagname;
    public GameObject shootpoint;

    public int dmgBullet;
    public EnemyScript enemy;

     
    void OnEnable()
    {

        StartCoroutine(SetDisabled(TimeToDisable));

        Transform parent = transform.parent;
        ParentPointShot = parent;

        twrScript = ParentPointShot.gameObject.GetComponent<Towerscript>();
        dmgBullet = twrScript.dmg;
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
        
        transform.Translate(Vector3.forward * speedBullet * Time.deltaTime);

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyOne")
        { 
            enemy = collision.gameObject.GetComponent<EnemyScript>();
             enemy.healthEnemy = enemy.healthEnemy - dmgBullet;
            enemy.TriggerHealth();

            gameObject.SetActive(false);
            gameObject.transform.parent = ParentPointShot;
            gameObject.transform.rotation = ParentPointShot.transform.rotation;

        }

    }


}
