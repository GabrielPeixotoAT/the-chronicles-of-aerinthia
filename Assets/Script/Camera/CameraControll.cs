using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public Transform target;

    void Awake()
    {
        var targetObj = GameObject.FindGameObjectsWithTag("Player");

        if (targetObj != null )
            target = targetObj.First().transform;
    }

    void LateUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (target != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = target.position.x;
            transform.position = newPosition;
        }
    }
}
