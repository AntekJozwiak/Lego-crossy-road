using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionKilla : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Delog"))
        {
            Debug.Log("aids lol");
            Destroy(this.gameObject);
        }
    }
}
