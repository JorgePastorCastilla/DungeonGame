using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShader : MonoBehaviour
{
    public Shader shader;
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        material.shader = shader;
    }
}
