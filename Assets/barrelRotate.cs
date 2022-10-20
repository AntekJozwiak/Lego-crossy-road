using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelRotate : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Vector3.right *  speed * Time.deltaTime);
    }
}
