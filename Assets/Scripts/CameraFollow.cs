using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 tempPos;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float yOffset = 3f;

    [SerializeField]
    private float minX, maxX;

    private void Update()
    {
        if (!target)
            return;

        tempPos = transform.position;
        tempPos.x = target.position.x;

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;
    }
}