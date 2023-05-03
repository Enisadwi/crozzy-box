using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    static HashSet<Vector3> positionSet;

    public static HashSet<Vector3> PositionSet {get => positionSet; }
    private void OnEnable()
    {
        positionSet.Add(item: this.transform.position);
    }

    // Update is called once per frame
    private void OnDisable()
    {
        positionSet.Remove(item: this.transform.position);  
    }
}
