using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
   [SerializeField] Grass grassPrefab;
   [SerializeField] Road roadPrefab;
   [SerializeField] int initialGrassCount =5;
   [SerializeField] int horizontalSize;
   [SerializeField] int backViewDistance =-4;
    [SerializeField] int forwardViewDistance =15;
   
   [SerializeField, Range (min: 0, max: 1  )] float treeProbability;

    private List<Terrain> terrainList;
    private void Start(){
        terrainList=new List<Terrain>
        {
            grassPrefab,roadPrefab
        };

   
    for (int zPos = backViewDistance; zPos <initialGrassCount; zPos++)
    {
        var grass = Instantiate(original: grassPrefab);
        grass.transform.localPosition=new Vector3(x:0, y:0, z:zPos);
        grass.SetTreePercentage(newProbability: zPos < -1 ? 1:0);
        grass.Generate(size: horizontalSize);
    }
     for (int zPos = initialGrassCount; zPos <forwardViewDistance; zPos++)
    {
        var randomIndex = Random.Range(minInclusive: 0, maxExclusive: terrainList.Count);
        var terrain = Instantiate(original: terrainList[index: randomIndex]);
        terrain.transform.localPosition=new Vector3(x:0, y:0, z:zPos);
        terrain.Generate(size: horizontalSize);
    }
   }
}
