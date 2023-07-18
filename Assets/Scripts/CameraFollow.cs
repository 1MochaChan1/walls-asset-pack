using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetTransform;
    public float followSpeed=2f;


  
    void Update()
    {
        transform.position = new Vector3(transform.position.x+5f*Time.deltaTime, transform.position.y, -10f);
        if(targetTransform != null)
        {
            Vector3 newPos = new Vector3(targetTransform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed*Time.deltaTime);
        }
    }
}
