using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public float speedBullet;

    public float TimeToDisable;
    public Transform ParentPointShot;

    public string tagname;
    public GameObject shootpoint;

  //  public GameObject target;
    void OnEnable()
    {

        StartCoroutine(SetDisabled(TimeToDisable));

        Transform parent = transform.parent;
        ParentPointShot = parent;
      
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
           // Debug.Log("bang");
            // collision.gameObject.SetActive(false);
            //collision.gameObject.TriggerHealth();
            gameObject.SetActive(false);
            gameObject.transform.parent = ParentPointShot;
            gameObject.transform.rotation = ParentPointShot.transform.rotation;

        }

        if (collision.tag == "Iron")
        {
            gameObject.SetActive(false);
            gameObject.transform.parent = ParentPointShot;
            gameObject.transform.rotation = ParentPointShot.transform.rotation;

        }
    }


}
