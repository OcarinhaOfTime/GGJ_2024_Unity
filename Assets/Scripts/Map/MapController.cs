using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapController : MonoBehaviour {
    public static MapController instance;
    public Map<Tile> map;
    public Tile prefab;
    public int width = 8;
    public int height = 8;
    public bool generateAtStart;

    void Awake(){
        instance = this;
    }

    void Start(){
        //if(generateAtStart){
        //    Generate();
        //}else{
        //    Load();
        //}
    }

    [ContextMenu("Generate")]
    public void Generate() {
        map = new Map<Tile>(width, height, CreateTile);
    }

    [ContextMenu("Clear")]
    public void Clear() {
        foreach(var tile in GetComponentsInChildren<Tile>()) { 
            DestroyImmediate(tile.gameObject);
        }

        print("All clear");
    }

    public int currentChild = 1;
    public void Load() {
        currentChild = 1;
        map = new Map<Tile>(width, height, LoadTile);
    }

    Tile CreateTile(int x, int y){
        var inst = Instantiate(prefab);
        inst.transform.SetParent(transform);
        //var min = new Vector2(-width/2, -height/2);
        var p = Map<Tile>.CoordToWorldPoint(x, y, width, height);
        inst.Setup(this);

        inst.transform.localPosition = Vector2.zero;
        inst.pos = p;
        inst.name = $"{x}x{y}";
        inst.gameObject.SetActive(true);
        inst.coord = new Vector2Int(x, y);        
        //inst.Deactive();
        //inst.HideSprites();
        return inst;
    }

    Tile LoadTile(int x, int y){
        var inst = transform.GetChild(currentChild++).GetComponent<Tile>();
        inst.name = $"{x}x{y}";
        //inst.gameObject.SetActive(true);
        //inst.coord = new Coord(x, y);    
        inst.Setup(this);
        //inst.Deactive();
        return inst;
    }
}
