using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {

        if (cam!=null)
        {
            // Checking how much distance is covered by the camera
            float distCovered = (cam.transform.position.x * (1-parallaxEffect));


            // Distance the sprite will move along with the camera.
            float distToMove = (cam.transform.position.x * parallaxEffect);

            // Moving the sprite along the x-axis on the by 'dist' units.
            transform.position= new Vector3(distToMove+startPos, transform.position.y, transform.position.z);



            if (distCovered > startPos + length)
            {
                // If distance covered by camera is more than starting position of the sprite,
                // then the sprite will be shifted by 'length' units
                startPos += length;
            }
            else if (distCovered < startPos - length)
            {
                // If distance covered by camera is less than starting position of the sprite,
                // then the sprite will be shifted by 'length' units
                startPos -= length;
            }
        }
    }
}
