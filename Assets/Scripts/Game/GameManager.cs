using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public MapController mapController;
    public CharacterController charController;

    [Range(0, 10)]public int items = 5;
    public ItemPickup prefab;
    //public List<ItemPickup> itemsPickups;
    public Dictionary<Vector2Int, ItemPickup> itemDict;

    void Awake() {
        instance = this;
    }

    private void Start() {
        mapController.Generate();
        var ws = new Vector2Int(mapController.width, mapController.height);
        var limw = mapController.map.CoordToWorldPoint(ws) - Vector2.one;
        print(limw);
        charController.lim_x = new Vector2(-limw.x, limw.x);
        charController.lim_y = new Vector2(-limw.y, limw.y);

        GenerateItems();
    }

    void GenerateItems() {
        var itemQueue = new ShufflerQueue<Tile>(mapController.map);
        itemDict = new Dictionary<Vector2Int, ItemPickup>();
        for (int i = 0; i < items; i++) {
            CreateItem(itemQueue.next);
        }
    }

    void CreateItem(Tile tile) {        
        var inst = Instantiate(prefab);
        inst.pos = tile.pos;
        inst.coord = tile.coord;
        inst.gameObject.SetActive(true);
        itemDict.Add(tile.coord, inst);
        inst.transform.SetParent(transform);
    }

    public ItemPickup AttemptGrabItem(Vector2Int c) {
        if (!itemDict.ContainsKey(c)) return null;

        var item = itemDict[c];
        itemDict.Remove(c);

        return item;
    }
}
