using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class IsoCamera : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 3f;
    public Vector3 offset;

    public float minX = -5f;
    public float maxX = 5f;

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            //smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX, maxX);

           
        }
    }
}


