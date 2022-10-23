using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStart : MonoBehaviour
{
    public GameObject cam;
    public GameObject cam1;



    void Start()
    {
        cam.SetActive(false);
        cam1.SetActive(true);
        //Time.timeScale = 0f;
        //GameObject player = GameObject.Find("Player");

    }
    public void startButtonUI()
    {
        cam.SetActive(true);
        cam1.SetActive(false);
    }

}
