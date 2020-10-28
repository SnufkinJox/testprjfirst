using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class loadLvl : MonoBehaviour
{
    public Transform HeroPosition;
    public GameObject Hero;
    public Transform[] startPosition;
    public GameObject[] Enemy;
    // Start is called before the first frame update
    void Start()
    {
        // load hero
        Instantiate(Hero.transform, HeroPosition.position, Quaternion.identity);
        // load enemys
        for (int i =0; i<Enemy.Length;i++)
        {
            Instantiate(Enemy[i].transform, startPosition[i].position, Quaternion.identity);
        }
    }

}
