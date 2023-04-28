using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] duck Duck;
   [SerializeField] List<Terrain> terrainList;
   [SerializeField] int initialGrassCount =5;
   [SerializeField] int horizontalSize;
   [SerializeField] int backViewDistance =-4;
    [SerializeField] int forwardViewDistance =15;
   
   [SerializeField, Range (min: 0, max: 1  )] float treeProbability;


    Dictionary<int, Terrain> activeTerrainDict = new Dictionary<int, Terrain>(capacity: 20);
    [SerializeField] private int travelDistance;
    private void Start(){
   
    for (int zPos = backViewDistance; zPos <initialGrassCount; zPos++)
    {
        var terrain = Instantiate(original: terrainList[index: 0]);
        terrain.transform.position=new Vector3(x:0, y:0, z:zPos);
        if (terrain is Grass grass)
        {
            grass.SetTreePercentage(newProbability: zPos < -1 ? 1:0);
        }
        
        terrain.Generate(size: horizontalSize);
        activeTerrainDict[key: zPos] = terrain ;
    }
     for (int zPos = initialGrassCount; zPos <forwardViewDistance; zPos++)
    {
       var terrain = SpawnRandomTerrain(zPos: zPos);
        terrain.Generate(size: horizontalSize);

         activeTerrainDict[key: zPos] = terrain;
    }
        SpawnRandomTerrain(zPos: 0);
   }

   private Terrain SpawnRandomTerrain(int zPos)
   {
    Terrain terrainCheck = null;
    int randomIndex;
    Terrain terrain = null;

    for (int z= -1; z >= -3; z--)
    {
        var checkPos = zPos +z;

        if (terrainCheck == null)
        {
            terrainCheck = activeTerrainDict[key: checkPos];
            continue;
        }
        else if (terrainCheck.GetType() != activeTerrainDict[key: checkPos].GetType())
        { 
             randomIndex = Random.Range(minInclusive: 0, maxExclusive: terrainList.Count);
             terrain = Instantiate(original: terrainList[index: randomIndex]);
             terrain.transform.position = new Vector3(x:0, y:0, z: zPos);
             return terrain;
        }
        else
        {
            continue;
        }
        
    }
    var candidateTerrain = new List<Terrain>(collection: terrainList);
    for (int i = 0; i < candidateTerrain.Count; i++)
    {
        if (terrainCheck.GetType() == candidateTerrain[index: i].GetType())
        {
            candidateTerrain.Remove(item: candidateTerrain[index :i]);
            break;
        }
    }
    randomIndex = Random.Range(minInclusive: 0, maxExclusive: candidateTerrain.Count);
    terrain = Instantiate(original: candidateTerrain[index: randomIndex]);
    terrain.transform.position = new Vector3(x: 0, y:0, z: zPos);
    return terrain;
   }

   public void UpdateTravelDistance(Vector3 targetPosition)
{
    if (targetPosition.z > travelDistance)
    {
     travelDistance = Mathf.CeilToInt(f: targetPosition.z);
    }
   }
   }
