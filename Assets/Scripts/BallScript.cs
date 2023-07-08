using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public ParticleSystem debrisParticle;
    public Rigidbody2D parentBody;

    void Start()
    {
        parentBody = GetComponent<Rigidbody2D>(); 
    }

    
    void Update()
    {
        Vector2 parentPost = parentBody.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contactPoint = collision.GetContact(0);
        Vector2 contactPos = contactPoint.point;        Vector2 currentPos = debrisParticle.transform.position;

        // Calculate angle between the contact position and the current position.
        var angleBetween = Mathf.Acos(Vector2.Dot(currentPos, contactPos)/(currentPos.magnitude * contactPos.magnitude));

        // Rotate the particle by the 'angleBetween' on the z axis
        debrisParticle.transform.SetPositionAndRotation(contactPos, new Quaternion(0,0,angleBetween,1));


        if (debrisParticle != null && parentBody.velocity.magnitude > 5.0f)
        {
            debrisParticle.Play();
        }
    }


}


