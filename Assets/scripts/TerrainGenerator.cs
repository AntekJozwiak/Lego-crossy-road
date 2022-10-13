using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> TerrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;
    [SerializeField] private GameObject player;

    private Vector3 currentPosition = new Vector3(0, 0, 0);
    [SerializeField] private List<GameObject> currentTerrains = new List<GameObject>();
    [SerializeField] private float playerdis;
    [SerializeField] private Vector3 playerstartpos;
    [SerializeField] private TerrainData defaultterrain;


    private void Start()
    {
        SpawnTerrain(true);

        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true);
        }
        maxTerrainCount = currentTerrains.Count;
    }

    private void Update()
    {

    }

    public void SpawnTerrain(bool isStart)
    {
        if (isStart || Vector3.Distance(player.transform.position, currentTerrains[currentTerrains.Count - 1].transform.position) <= playerdis)
        {
            if (isStart) playerstartpos = player.transform.position;
            int whichTerrain = Random.Range(0, TerrainDatas.Count);
            int terrainInSuccession = Random.Range(1, TerrainDatas[whichTerrain].maxInSuccession);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain;
                if (currentPosition.z != playerstartpos.z)
                {
                    terrain = Instantiate(TerrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity, terrainHolder);
                }
                else
                {
                    terrain = Instantiate(defaultterrain.terrain, currentPosition, Quaternion.identity, terrainHolder);

                }
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
            if (isStart)
            {
                playerdis = Vector3.Distance(player.transform.position, currentTerrains[currentTerrains.Count - 1].transform.position);
                playerstartpos = player.transform.position;
            }
        }
    }


}