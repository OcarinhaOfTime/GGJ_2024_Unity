using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    MapController mapController;
    public Vector2 pos {
        get => new Vector2(transform.localPosition.x, transform.localPosition.z);
        set => transform.localPosition = new Vector3(value.x, transform.localPosition.y, value.y);
    }

    public Vector2Int coord;

    private void Start() {
        mapController = MapController.instance;

    }

    private void Update() {
        coord = mapController.map.WorldPointToCoord(pos);
    }
}
