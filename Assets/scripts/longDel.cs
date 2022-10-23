using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longDel : MonoBehaviour
{
    private void Awake()
    {
        Destroy(this.gameObject, 40);
    }
}
