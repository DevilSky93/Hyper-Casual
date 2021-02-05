using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private bool x, y, z;
    [SerializeField] private Transform target;
    
     [SerializeField] 
     private float smoothSpeed = .125f;

     [SerializeField] private Vector3 offset;
     private Vector3 velocity = Vector3.zero;
     private Vector3 desiredPosition;

     private void FixedUpdate()
     {
         desiredPosition = target.position + offset;
         var lockTarget = desiredPosition;
         var position = transform.position;
         lockTarget = x ? new Vector3(desiredPosition.x, lockTarget.y, lockTarget.z) : new Vector3(position.x, lockTarget.y, lockTarget.z);

         lockTarget = y ? new Vector3(lockTarget.x, desiredPosition.y, lockTarget.z) : new Vector3(lockTarget.x, position.y, lockTarget.z);
         
         lockTarget = z ? new Vector3(lockTarget.x, lockTarget.y, desiredPosition.z) : new Vector3(lockTarget.x, lockTarget.y, position.z);

         var smoothedPosition = Vector3.SmoothDamp(position, lockTarget, ref velocity, smoothSpeed);
         position = smoothedPosition;
         transform.position = position;
     }
}
