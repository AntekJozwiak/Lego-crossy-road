using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossyroadmovement : MonoBehaviour
{
    [SerializeField]
    float mspeed;
    [SerializeField]
    float rspeed;
    void Start()
    {
        //transform.position = new Vector3(transform.position.x -.5f, transform.position.y, transform.position.z);
    }
    public LayerMask acid;
    public bool moving;
    Vector3 moveto;
    Quaternion rotateto;
    public GameObject terraingen;
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,-transform.up, out hit))
        {
            transform.parent = hit.transform;
        }
        if (!moving)
        {
            if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
            {
                moveto = transform.position + new Vector3(0, 0, 1);
                rotateto = Quaternion.Euler(0, 0, 0);
                moving = true;
                terraingen.GetComponent<TerrainGenerator>().SpawnTerrain(false);
            }
            else if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
            {
                moveto = transform.position - new Vector3(0, 0, 1);
                rotateto = Quaternion.Euler(0, 180, 0);
                moving = true;
            }
            else if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
            {
                moveto = transform.position + new Vector3(1, 0, 0);
                rotateto = Quaternion.Euler(0, 90, 0);
                moving = true;
            }
            else if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
            {
                moveto = transform.position - new Vector3(1,0,0);
                rotateto = Quaternion.Euler(0, -90, 0);
                moving = true;
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
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, Mathf.Infinity, acid))
        {
            Debug.DrawRay(transform.position, -transform.up);
        }


    }

}
