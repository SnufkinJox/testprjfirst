using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HeroClass : MonoBehaviour
{
    private float speed;
    private int hearts;
    private float startShts;

    private Transform shoothole;
    public GameObject bullet;

    private float timeBTWsht;

    private Joystick Joy;
    public LayerMask whatIsWall;

    private static Vector3 lastPosition;
    public void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        Joy = obj.GetComponent<Joystick>();
        speed = 0.25f;
        hearts = 7;
        startShts = 2;
        shoothole = GameObject.FindGameObjectWithTag("HrHole").transform;

    }

    // Update is called once per frame
    void Update()
    {
        // walking and rotating
        Collider[] isWall = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), 1, whatIsWall);

        if (isWall.Length <= 0)
        {

            lastPosition = new Vector3(transform.position.x, 1, transform.position.z);
            transform.position = new Vector3(transform.position.x + (Joy.Horizontal* speed), 1, transform.position.z + (Joy.Vertical * speed));
            Quaternion target = Quaternion.Euler(0, Mathf.Atan(Joy.Horizontal / Joy.Vertical) * (180 / Mathf.PI), 0);
            transform.rotation = target;
           
        }
        else
        {
            transform.position = lastPosition;
            Quaternion target = Quaternion.Euler(0, Mathf.Atan(Joy.Horizontal / Joy.Vertical) * (180 / Mathf.PI), 0);
            transform.rotation = target;
        }

        // Bullet
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");
        if (obj.Length != 0)
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
        
        //Death
        if (hearts == 0)
        {
            SceneManager.LoadScene(1);
            //Destroy(gameObject);
        }
    }

    public void HeroDamage()
    {
        Debug.Log(hearts);
        hearts--;
    }
}
