using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using UnityEngine;

public class BulletClass : MonoBehaviour
{
    public float bulletspeed;
    public LayerMask whatIsWall;
    public LayerMask whatIsGoal;

    public string targettag;
    private GameObject[] obj;
    private Transform pos;
    private Vector3 target;
    private float DistMin;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
       
        obj = GameObject.FindGameObjectsWithTag(targettag);
        if (obj.Length > 1)
        {
            float currentdist;
            DistMin = 99999999;
            int numb = 0;

            foreach (GameObject Mob in obj)
            {
                currentdist = Vector3.Distance(transform.position, Mob.transform.position);
                if (currentdist < DistMin)
                {
                    DistMin = currentdist;
                    index = numb;

                }
                numb++;
            }


        }
        else
        {
            index = 0;
        }

        target = new Vector3(obj[index].transform.position.x, obj[index].transform.position.y, obj[index].transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target, bulletspeed * Time.deltaTime);

            Collider[] isWall = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 1, whatIsWall);
            Collider[] isPlayer = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 1, whatIsGoal);


            if (isPlayer.Length != 0)
            {
            Debug.Log(targettag);
            if (targettag == "Enemy")
            { obj[index].GetComponent<EnemyClass>().Damage(); }
            else if (targettag == "Player")
            {
                obj[index].GetComponent<HeroClass>().HeroDamage();
            }
            else if (isWall.Length != 0)
            {
                Destroy(gameObject);
            }
            Destroy(gameObject);
            }
            else if ((transform.position.x == target.x) || (transform.position.z == target.z))
            {
                Destroy(gameObject);
            }
        
    }

}

