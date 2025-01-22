using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private float length, startpos;
    private GameObject cam;
    public float parallaxEffect;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        startpos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    
    void FixedUpdate()
    {
        float temp = (cam.transform.position.y * (1 - parallaxEffect));
        float dist = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startpos + dist, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp > startpos + length)
        {
            startpos -= length;
        }
    }
}
