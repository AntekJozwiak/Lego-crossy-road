using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionKilla : MonoBehaviour
{
    private void Awake()
    {
        Destroy(this.gameObject, 15);
    }
}
