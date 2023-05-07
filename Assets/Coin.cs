using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField, Range(min: 0, max: 10)] float rotationSpeed =1;

    public int Value {get => value;}

    public void Collected()
    {
        GetComponent<Collider>().enabled = false;
        rotationSpeed *= 5;
        this.transform.DOJump(
            endValue: this.transform.position,
            jumpPower: 2,
            numJumps: 1,
            duration: 0.5f).onComplete = SelfDestruct;
        
    }

    private void SelfDestruct()
    {
        Destroy(obj: this.gameObject);
    }



    void Update()
    {
        transform.Rotate(xAngle: 0,yAngle: 360*rotationSpeed*Time.deltaTime,zAngle: 0);
    } 
}
