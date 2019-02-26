using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfBG : MonoBehaviour
{
    public float ScrollSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0,Time.time * ScrollSpeed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
