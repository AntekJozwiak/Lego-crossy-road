using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obspawner : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public GameObject[] objcts;
    public Vector2 timerange;
    public bool r;
    public Vector2 amountprerange;
    private void Start()
    {
        if (transform.position.z % 2 == 0)
        {
            r = true;
        }
        int amount = Mathf.RoundToInt(Random.Range(amountprerange.x, amountprerange.y));
        int i = 0;
        while (i < amount)
        {
            if (r) Instantiate(objcts[Random.Range(0, objcts.Length)], new Vector3(Random.Range(left.position.x, right.position.x), right.position.y, right.position.z), right.transform.rotation);
            else Instantiate(objcts[Random.Range(0, objcts.Length)], new Vector3(Random.Range(left.position.x, right.position.x), right.position.y, right.position.z), left.transform.rotation);
            Debug.Log("myballs");
            i++;
        }
        StartCoroutine(loop());
    }
    IEnumerator loop()
    {
        while (true)
        {

            float time = Random.Range(timerange.x, timerange.y);
            yield return new WaitForSeconds(time);
            if (r) Instantiate(objcts[Random.Range(0, objcts.Length)], right.transform.position, right.transform.rotation);
            else Instantiate(objcts[Random.Range(0, objcts.Length)], left.transform.position, left.transform.rotation);

        }
    }
}