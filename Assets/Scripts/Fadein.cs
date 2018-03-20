using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadein : MonoBehaviour {
    public MeshRenderer[] renderers;
    float alpha = 255.0f;
    Color color;
    void Start()
    {
        renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer render in renderers)
        {
            color = render.material.color;
            color.a = 1f;
            render.material.color = color;
            //render.enabled = false;
        }


    }

    void Update()
    {
        foreach (MeshRenderer render in renderers)
        {
            if (color.a > 0)
            {
                color = render.material.color;
                color.a -= 0.05f;
                render.material.color = color;
            }
            //render.enabled = false;
        }
    }
        
        //Color alphaFadedColor = Color.white;

        // modify alpha
        // create your own time based algorithm and start it when you want the fade to start
       // alphaFadedColor.a = Time.realtimeSinceStartup / 10f;
       // foreach (SpriteRenderer renderer in renderers)
       // {
      //      renderer.color = alphaFadedColor;
      //  }
}
