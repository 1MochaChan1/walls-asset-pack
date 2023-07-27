using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSwayController : MonoBehaviour
{
    public new SpriteRenderer renderer;

    public float windStrength;
    public float windSpeed;



    private void Start()
    {
        if (renderer != null)
        {
            renderer.material.SetFloat("_WindSpeed", windSpeed);
            renderer.material.SetFloat("_WindStrenght", windStrength);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //if (renderer != null)
        //{
        //    renderer.material.SetFloat("_WindSpeed", windSpeed);
        //    renderer.material.SetFloat("_WindStrenght", windStrength);
        //}
    }
}
