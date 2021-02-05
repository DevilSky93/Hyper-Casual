using System.Collections;
using System.Collections.Generic;
using Events.Bool;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private LayerMask interactionCollider;
    [SerializeField] private bool valueToGive;
    
    [SerializeField] private EventBool stopGameEvent;
    [SerializeField] private EventBool gameOverEvent;
    private void OnTriggerEnter(Collider other)
    {
        if ((interactionCollider.value & 1 << other.gameObject.layer) > .1f)
        {
            stopGameEvent.Raise(valueToGive);
            gameOverEvent.Raise(valueToGive);
        }
    }
}
