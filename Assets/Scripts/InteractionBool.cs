using System.Collections;
using System.Collections.Generic;
using Events.Bool;
using UnityEngine;

public class InteractionBool : MonoBehaviour
{
    [SerializeField] private LayerMask interactionCollider;
    [SerializeField] private bool valueToGive;
    
    [SerializeField] private EventBool eventToRaise;
    
    private void OnTriggerEnter(Collider other)
    {
        if ((interactionCollider.value & 1 << other.gameObject.layer) > .1f)
        {
            eventToRaise.Raise(valueToGive);
        }
    }
}
