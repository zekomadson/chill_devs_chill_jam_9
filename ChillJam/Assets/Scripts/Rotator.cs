using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    
    void Update()
    {
        float xRotate = 175f;
        float yRotate = 0f;
        float zRotate = 0f;
        
        transform.Rotate(new Vector3(xRotate, yRotate,zRotate) * Time.deltaTime);
    }
}
