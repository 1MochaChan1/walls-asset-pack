using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallGlowController : MonoBehaviour
{
    public new SpriteRenderer renderer;
    [ColorUsage(true, true)]
    public Color glowColor;
    //public Texture2D mainTexture;
    public Texture2D glowMaskTexture;

    private void Start()
    {
        if(renderer != null)
        {
            renderer.material.SetColor("_GlowColor", glowColor);
            renderer.material.SetTexture("_MainText", renderer.sprite.texture);
            renderer.material.SetTexture("_GlowMaskTex", glowMaskTexture);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //renderer.material.SetColor("_GlowColor", glowColor);
        //renderer.material.SetTexture("_MainText", renderer.sprite.texture);
        //renderer.material.SetTexture("_GlowMaskTex", glowMaskTexture);
    }
}
