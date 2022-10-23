using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapEnd : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent("deathMenu");



        }
    }


}
