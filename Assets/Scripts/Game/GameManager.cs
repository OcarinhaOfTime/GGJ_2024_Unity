using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public MapController mapController;
    public CharacterController charController;

    private void Start() {
        mapController.Generate();
        var ws = new Vector2Int(mapController.width, mapController.height);
        var limw = mapController.map.CoordToWorldPoint(ws) - Vector2.one;
        print(limw);
        charController.lim_x = new Vector2(-limw.x, limw.x);
        charController.lim_y = new Vector2(-limw.y, limw.y);
    }
}
