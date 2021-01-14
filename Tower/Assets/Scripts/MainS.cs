using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MainS : MonoBehaviour
{
    public float TimenextWave;

    public string nametower;
    public Towerscript tw;

    public int Gold;
    public TextMesh txtGold;
    public GameObject[] waypoints;

    public int healthCastle;
    public Text txtHealth;
    public Createenemy createenemyScript;
   
    public int numWave;
    public int numEnemyinWave;
    public int destroyEnemy;

    public EnemyScript enemyscript;

    public Text txtNumWave;

    public GameObject Gameoverpanel;
    public int AlldestroyEnemy;
    public Text txtAlldestroyEnemy;


    public GameObject Updatemenu;

    public Text txt;
   
    void Start()
    {
        txtGold.text = Gold.ToString();
        destroyEnemy = numEnemyinWave;
        txtNumWave.text = "Wave: " + numWave.ToString();
        txtHealth.text = "Health: " + healthCastle.ToString();
        Readfile();
    }

    public void Readfile()
    {
        string[] textfile = File.ReadAllLines("Assets/Resources/time.txt");
                string text = textfile[0];
        float num = float.Parse(text);
        TimenextWave = num;
      
        
    }

    void Update()
    {
     
   
    }

    public void CreateEnemyStop()
    {
    
       
    
        if (createenemyScript.Colvosozdannih >= numEnemyinWave)
        {
         createenemyScript.Colvosozdannih = 0;
            createenemyScript.create = false;

            StartCoroutine(Zapusk());
        }
      
        if (healthCastle <= 0)
        {
            Gameoverpanel.SetActive(true);
            txtAlldestroyEnemy.text = AlldestroyEnemy.ToString();
            createenemyScript.create = false;

        }
    
    }
    IEnumerator Zapusk()
    {
        yield return new WaitForSeconds(TimenextWave);
        numWave = numWave + 1;
        createenemyScript.create = true;
        CreateEnemyStart();
    }
    public void CreateEnemyStart()
    {
      
        createenemyScript.enabled = true;
           
        destroyEnemy = numEnemyinWave + numWave * Random.Range(0, numEnemyinWave + 10);
        healthCastle = 10;
       
        createenemyScript.CreateEnemyingame();
             
        txtNumWave.text = "Wave: " + numWave.ToString();
       
    }

    public void Restartgame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void UpdateMenu()
    {
        Updatemenu.SetActive(true);
    }

    public void CloseUpdateMenu()
    {
        Updatemenu.SetActive(false);
    }

    public void Upgardetwr()
    {
        tw.UpgradeTower();
        CloseUpdateMenu();
    }
}
