using System;
using System.Collections;
using System.Collections.Generic;
using Events.Float;
using UnityEngine;

public class InteractionFloat : MonoBehaviour
{
    [SerializeField] private LayerMask interactionCollider;
    [SerializeField] private float valueToGive;
    
    [SerializeField] private EventFloat eventToRaise;
    [SerializeField] private bool willBeDestroyed;
    private void OnTriggerEnter(Collider other)
    {
        if ((interactionCollider.value & 1 << other.gameObject.layer) > .1f)
        {
            eventToRaise.Raise(valueToGive);
            if (willBeDestroyed)
            {
                Destroy(gameObject);
            }
        }
    }
}
