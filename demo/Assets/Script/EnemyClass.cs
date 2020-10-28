
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    private float enemyspeed;
    private float enemytime;
    private int enemyheart;

    private Transform shoothole;
    public GameObject bullet;

    private float timeBTWsht;
    private float startShts;

    private GameObject[] spots;
    private int randomSpot;
    private float waittime;
    private string enemyindex;

    public void Start()
    {
        enemyindex = (Regex.Match(gameObject.name, @"\d+").Value);
        spots = GameObject.FindGameObjectsWithTag("EnemyPotr" + enemyindex);
        shoothole = GameObject.FindGameObjectsWithTag("Hole")[System.Convert.ToInt32(enemyindex)].transform;
        
        enemyheart = 2;
        enemyspeed = 4;
        enemytime = 2;
        startShts = 3;

        randomSpot = Random.Range(0, spots.Length);
        timeBTWsht = startShts;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, spots[randomSpot].transform.position, enemyspeed*Time.deltaTime);
        
        if(Vector3.Distance(transform.position, spots[randomSpot].transform.position) <0.2f)
        {
            if(waittime<=0)
            {
                randomSpot = Random.Range(0, spots.Length);
                waittime = enemytime;
            }
            else
            {
                waittime -= Time.deltaTime;
            }
        }
        if (GameObject.FindGameObjectsWithTag("Player").Length != 0)
        {
            if (timeBTWsht <= 0)
            {
                Instantiate(bullet, shoothole.position, Quaternion.identity);
                timeBTWsht = startShts;
            }
            else
            {
                timeBTWsht -= Time.deltaTime;
            }
        }

        if(enemyheart==0)
        {
            Restart();
        }    
    
    }

    public void Damage()
    {
        enemyheart--;
    }

    public void Restart()
    {
        enemyheart = 2;
        enemyspeed = 4;
        enemytime = 2;
        startShts = 3;

        randomSpot = Random.Range(0, spots.Length);
        timeBTWsht = startShts;
        transform.position = new Vector3(spots[randomSpot].transform.position.x,1, spots[randomSpot].transform.position.z);
    }
}
