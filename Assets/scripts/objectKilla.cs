using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectKilla : MonoBehaviour
{
    public float wait;

    private void update()
    {

         Destroy(gameObject, wait);


    }
}
