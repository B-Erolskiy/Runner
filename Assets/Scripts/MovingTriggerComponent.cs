using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTriggerComponent : TriggerComponent
{
    [SerializeField] private List<Vector3> movePoints = new List<Vector3>();
    [SerializeField] private float speed;
    
    protected override void Start()
    {
        base.Start();

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        int currentPointNumber = 0;
        while (true)
        {
            yield return StartCoroutine(MoveToLocalPoint(movePoints[currentPointNumber]));
            currentPointNumber = currentPointNumber >= movePoints.Count - 1 ? 0 : currentPointNumber + 1;
            
            yield return null;
        }
    }

    private IEnumerator MoveToLocalPoint(Vector3 point)
    {
        while (transform.localPosition != point)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, point,
                speed * Time.deltaTime);
            yield return null;
        }
    }
}