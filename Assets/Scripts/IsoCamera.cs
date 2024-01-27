using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class IsoCamera : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    public float minX = -5f;
    public float maxX = 5f;
    private void Update()
    {
        Vector3 desiredPosition = player.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(Transform.position, desiredPosition, smoothSpeed);

        //smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX, maxX);

        transform.position = desiredPosition;
    }
}
   
