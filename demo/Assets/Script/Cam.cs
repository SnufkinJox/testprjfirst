using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform target;

    // Update is called once per frame
    void LateUpdate()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        target = obj.transform;

        transform.position = new Vector3(target.position.x, 30, target.position.z);
    }
}
