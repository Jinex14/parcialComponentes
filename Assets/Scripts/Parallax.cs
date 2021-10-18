using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float[] speeds;

    void Update()
    {
        for(int i = 0; i<transform.childCount; i++)
        {
            Debug.Log(i);
            Renderer rnd = transform.GetChild(i).GetComponent<Renderer>();
            rnd.material.mainTextureOffset = new Vector2(rnd.material.mainTextureOffset.x + (speeds[i] * Time.deltaTime),0);
        }
    }
}
