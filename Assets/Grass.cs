using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Terrain
{
   [SerializeField] List <GameObject> treePrefab;
   [SerializeField, Range (min: 0, max:1)] float treeProbability; 

    public void SetTreePercentage(float newProbability)
    {
        this.treeProbability = Mathf.Clamp01(value: newProbability);
    }

   public override void Generate(int size)
    {
        base.Generate(size: size);

        var limit= Mathf.FloorToInt(f: (float)size /2);
        var treeCount= Mathf.FloorToInt(f: (float)size * treeProbability);

        List<int> emptyPosition = new List<int>();
        for (int i = -limit; i <= limit; i++)
        {
            emptyPosition.Add(item: i);
        }

      
        for (int i = 0; i < treeCount; i++)
        {
            
            var randomIndex= Random.Range(minInclusive: 0, maxExclusive: emptyPosition.Count);
            var pos= emptyPosition[index: randomIndex];

            emptyPosition.RemoveAt(index: randomIndex);

            SpawnRandomTree(xpos: pos);
        }

        SpawnRandomTree(xpos: -limit -1);
        SpawnRandomTree(xpos: limit +1);
        }


private void SpawnRandomTree(int xpos)
{
        
            var randomIndex = Random.Range(minInclusive: 0, 
            maxExclusive: treePrefab.Count);
            var prefab = treePrefab[index: randomIndex];

            var tree = Instantiate(
                original: prefab, 
                position: new Vector3 (x: xpos, y: 0, z: this.transform.position.z),
                rotation: Quaternion.identity,
                parent: transform);
            
          
        }
    }

