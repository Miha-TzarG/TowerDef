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
    public Text txtGold;
    public GameObject[] waypoints;

    public int healthCastle;
    public Text txtHealth;
    public Createenemy createenemyScript;
   
    public int numWave;
    public int numEnemyinWave;
    public int destroyEnemy;
    public int HowmuchEnemy;

    public EnemyScript enemyscript;

    public Text txtNumWave;

    public GameObject Gameoverpanel;
    public int AlldestroyEnemy;
    public Text txtAlldestroyEnemy;


    public GameObject Updatemenu;

    public Text txt;
   
  
    void Start()
    {
      
        Time.timeScale = 1;
        txtGold.text = "Gold: "+ Gold.ToString();
        destroyEnemy = numEnemyinWave;
        txtNumWave.text = "Wave: " + numWave.ToString();
        txtHealth.text = "Health: " + healthCastle.ToString();
        HowmuchEnemy = destroyEnemy;


        Readfile();
    }

    private void Update()
    {
        if(destroyEnemy == 0)
        {
        
            destroyEnemy = numEnemyinWave;
            StartCoroutine(Zapusk());
        }

    }
    public void Readfile()
    {
        string[] textfile = File.ReadAllLines("Assets/Resources/time.txt");
                string text = textfile[0];
        float num = float.Parse(text);
        TimenextWave = num;
      
        
    }

    public void Stop()
    {
       createenemyScript.Colvosozdannih = 0;
      createenemyScript.create = false;
      
    }

    public void CreateEnemyStop()
    {
      
    
        if (healthCastle <= 0)
        {
            OpenMenu();
            
            createenemyScript.create = false;

        }
    
    }
    IEnumerator Zapusk()
    {
        yield return new WaitForSeconds(TimenextWave);
        createenemyScript.Colvosozdannih = 0;
        numWave = numWave + 1;
        createenemyScript.create = true;
        CreateEnemyStart();
    }
    public void CreateEnemyStart()
    {
      
     
           
        destroyEnemy = numEnemyinWave + numWave * Random.Range(0, numEnemyinWave + 10);
        HowmuchEnemy = destroyEnemy;
      
       
        createenemyScript.CreateEnemyingame();
             
        txtNumWave.text = "Wave: " + numWave.ToString();
       
    }
    public void OpenMenu()
    {
        Time.timeScale = 0;
        Gameoverpanel.SetActive(true);
        txtAlldestroyEnemy.text = AlldestroyEnemy.ToString();
    }

    public void ContiniuGame()
    {
        Time.timeScale = 1;
        Gameoverpanel.SetActive(false);


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
