using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class duckCamera : MonoBehaviour
{
[SerializeField] private Vector3 offset;
[SerializeField, Range(min: 0, max:1)] float moveDuration = 0.2f;


    // Start is called before the first frame update
    private void Start()
    {
        offset = this.transform.position;
    }

    // Update is called once per frame
    public void UpdatePosition(Vector3 targetPosition)
    {
        DOTween.Kill(targetOrId: this.transform);
        transform.DOMove(endValue: offset+targetPosition, duration: moveDuration);
    }
}
