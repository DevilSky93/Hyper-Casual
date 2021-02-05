using System;
using System.Collections;
using System.Collections.Generic;
using Events.Float;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float timeBeforeDestroy;
    private float timeBeforeDestroyCounter;
    [SerializeField] private LayerMask interactionMask;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private float dmgValue;
    [SerializeField] private EventFloat hitPlayer;
    // Start is called before the first frame update
    void Start()
    {
        timeBeforeDestroyCounter = timeBeforeDestroy;
    }

    // Update is called once per frame
    public void OnUpdate(bool isStarted)
    {
        if (isStarted)
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
            transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
            if (timeBeforeDestroyCounter > 0)
            {
                timeBeforeDestroyCounter -= Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((interactionMask.value & 1 << other.gameObject.layer) > .1f)
        {
            hitPlayer.Raise(dmgValue);
            Destroy(gameObject);
        }
    }
}
