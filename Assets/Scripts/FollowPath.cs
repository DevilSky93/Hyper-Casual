using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private List<Transform> points;
    [SerializeField] private float moveDuration;
    private List<Vector3> pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = new List<Vector3>();
        foreach (var point in points)
        {
            pos.Add(point.position);
        }
        target.transform.DOPath(pos.ToArray(), moveDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
