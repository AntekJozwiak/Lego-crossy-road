using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> TerrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;
    public GameObject player;
   
    private Vector3 currentPosition = new Vector3(0, 0, 0);
    private List<GameObject> currentTerrains = new List<GameObject>();



    private void Start()
    {
        SpawnTerrain(true);

        for (int i  = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true);
        }
        maxTerrainCount = currentTerrains.Count;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            //SpawnTerrain(false);
        }
    }

    public void SpawnTerrain(bool isStart)
    {
        int whichTerrain = Random.Range(0, TerrainDatas.Count);
        int terrainInSuccession = Random.Range(1, TerrainDatas[whichTerrain].maxInSuccession);
        for (int i = 0; i < terrainInSuccession; i++)
        {
            GameObject terrain = Instantiate(TerrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity, terrainHolder);
            currentTerrains.Add(terrain);
            if (!isStart)
            {
                if (currentTerrains.Count > maxTerrainCount)
                {
                    Destroy(currentTerrains[0]);
                    currentTerrains.RemoveAt(0);
                }
            }
            
            currentPosition.z++;
        }

    }


}
