using System.Collections;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Objects;
    [SerializeField] private GameObject terrainHolder;

    void Awake()
    {
        terrainHolder = GameObject.Find("terrain holder"); 
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        int spawnCount = 0;
        while (spawnCount < 5)
        {
            int xPos = Random.Range(-5, 6);
            GameObject newObj = Instantiate(Objects[Random.Range(0, Objects.Length)], new Vector3(transform.position.x +  xPos, transform.position.y + 1, transform.position.z), Quaternion.identity);
            newObj.transform.SetParent(terrainHolder.transform);
            yield return new WaitForSeconds(0.1f);
            spawnCount += 1;
        }
    }

}
