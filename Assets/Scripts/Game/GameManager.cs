using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public MapController mapController;
    public CharacterController charController;

    private void Start() {
        mapController.Generate();
        var ws = new Vector2Int(mapController.width, mapController.height);
        var limx = mapController.map.CoordToWorldPoint(ws);
        print(limx);
        //charController.lim_x
    }
}
