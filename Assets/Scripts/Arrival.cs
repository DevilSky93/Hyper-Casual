using System;
using System.Collections;
using System.Collections.Generic;
using Events.Bool;
using UnityEngine;

public class Arrival : MonoBehaviour
{
    [SerializeField] private LayerMask interactionMask;

    [SerializeField] private EventBool gameOverEvent, gameStateEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((interactionMask.value & 1 << other.gameObject.layer) > .1f)
        {
            gameOverEvent.Raise(true);
            gameStateEvent.Raise(false);
        }
    }
}
