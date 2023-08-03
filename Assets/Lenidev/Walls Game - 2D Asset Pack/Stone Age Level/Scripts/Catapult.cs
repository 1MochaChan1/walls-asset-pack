using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public Rigidbody2D slingBody;
    public Transform launchTarget;
    public Transform slingCup;

    public float slingForce;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var dir = (slingCup.position - launchTarget.position).normalized;
            slingBody.AddForceAtPosition(dir*-slingForce*100f, launchTarget.position);
        }
    }
}
