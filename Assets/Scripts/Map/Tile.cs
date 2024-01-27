using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour {
    public HideFlags customHideFlags;
    public Vector2Int coord;
    public int x => coord.x;
    public int y => coord.y;
    public int cost = 1;
    public int cost_value { set { cost = value; } }
    MapController controller;

    public Vector2 pos {
        get => new Vector2(transform.localPosition.x, transform.localPosition.z);
        set => transform.localPosition = new Vector3(value.x, transform.localPosition.y, value.y);
    }

    public void Setup(MapController controller) {
        this.controller = controller;
    }    
}
