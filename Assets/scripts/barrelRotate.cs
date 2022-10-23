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
        transform.Rotate(new Vector3(0f, 0f * Time.deltaTime, 100f));
    }
}
