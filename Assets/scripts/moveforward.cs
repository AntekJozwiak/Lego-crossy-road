using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveforward : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
