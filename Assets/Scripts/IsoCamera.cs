using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class IsoCamera : MonoBehaviour
{
    public Transform player;
    public List<Transform> players;
    public float smoothSpeed = 3f;
    public Vector3 offset;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    public float minX = -5f;
    public float maxX = 5f;

     void Start()
    {
        var numberOfPlayers = players.Count;
        if (numberOfPlayers > 0) ;
    }
    private void LateUpdate()
    {
        if (players.Count == 0) return;

        Vector3 desiredPosition = offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
           
           smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
           smoothedPosition.z = Mathf.Clamp(smoothedPosition.z, minBounds.y, maxBounds.y);

            transform.position = smoothedPosition;


        
    }
}


