using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGround : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 vec3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            vec3.x -= 0.1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vec3.x += 0.1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vec3.z += 0.1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vec3.z -= 0.1f;
        }
        this.transform.position = vec3;
    }
}
