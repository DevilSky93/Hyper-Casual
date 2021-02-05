using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Events.Float;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private List<Vector3> newPos;
    [SerializeField] private float value;
    [SerializeField] private LayerMask interactionMask;
    [SerializeField] private EventFloat addGaugeEvent;

    [SerializeField] private GameObject collectableParticle;
    // Start is called before the first frame update
    void Start()
    {
        newPos = new List<Vector3>();
        var position = transform.position;
        newPos.Add(new Vector3(position.x, position.y+.5f, position.z));
        transform.DOPath(newPos.ToArray(), .8f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((interactionMask.value & 1 << other.gameObject.layer) > .1f)
        {
            Debug.Log("Add in gauge"); //TODO EVENT Add
            if (addGaugeEvent != null)
            {
                addGaugeEvent.Raise(value);
            }
            Instantiate(collectableParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
