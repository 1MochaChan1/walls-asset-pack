using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    public new SpriteRenderer renderer;

    public GameObject gameobject;
    public float windStrength;
    public float windSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer != null)
        {
            renderer.material.SetFloat("_WindSpeed", windSpeed);
            renderer.material.SetFloat("_WindStrenght", windStrength);
        }
    }
}
