using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossyroadmovement : MonoBehaviour
{
    [SerializeField]
    float mspeed;
    [SerializeField]
    float rspeed;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private string[] blockedobjects;

    void Start()
    {

    }
    public bool moving;
    Vector3 moveto;
    Quaternion rotateto;
    public GameObject terraingen;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            transform.parent = hit.transform;
        }
        if (!moving)
        {
            foreach (string i in blockedobjects)
            {
                if (i + "(Clone)" == hit.transform.name)
                {
                 // die();
                    if (hit.transform.name == "water(Clone)") anim.Play("drown");
                }
            }

            if (Input.GetKeyDown("w"))
            {

                moveto = transform.position + new Vector3(0, 0, 1);
                rotateto = Quaternion.Euler(0, 0, 0);
                moving = true;
                terraingen.GetComponent<TerrainGenerator>().SpawnTerrain(false);
                anim.Play("jump");
            }
            else if (Input.GetKeyDown("s"))
            {
                moveto = transform.position - new Vector3(0, 0, 1);
                rotateto = Quaternion.Euler(0, 180, 0);
                moving = true;
                anim.Play("jump");
            }
            else if (Input.GetKeyDown("d"))
            {
                moveto = transform.position + new Vector3(1, 0, 0);
                rotateto = Quaternion.Euler(0, 90, 0);
                moving = true;
                anim.Play("jump");
            }
            else if (Input.GetKeyDown("a"))
            {
                moveto = transform.position - new Vector3(1, 0, 0);
                rotateto = Quaternion.Euler(0, -90, 0);
                moving = true;
                anim.Play("jump");
            }
        }
        else
        {
            moving = true;
            moveto = new Vector3(Mathf.RoundToInt(moveto.x), moveto.y, Mathf.RoundToInt(moveto.z));
            transform.position = Vector3.MoveTowards(transform.position, moveto, mspeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateto, rspeed * Time.deltaTime);
            if (transform.position == moveto && transform.rotation == rotateto)
            {
                moving = false;
            }

        }
    }
    /*
    public void die()
    {
        GameObject deadobj = GameObject.FindGameObjectWithTag("deadobj");
        deadobj.GetComponent<deadobject>().dead = true;
        this.enabled = false;
    }
    */
}