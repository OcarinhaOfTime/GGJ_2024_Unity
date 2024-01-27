using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Vector2 lim_x;
    public Vector2 lim_y;
    public static GameManager instance;
    public MapController mapController;

    [Range(0, 10)]public int items = 5;
    public ItemPickup prefab;
    public Dictionary<Vector2Int, ItemPickup> itemDict;
    public IsoCamera isoCamera;
    public GameObject winPanel;

    public List<Player> players = new List<Player>();

    void Awake() {
        instance = this;
    }

    private void Start() {
        mapController.Generate();
        var ws = new Vector2Int(mapController.width, mapController.height);
        var limw = mapController.map.CoordToWorldPoint(ws) - Vector2.one;
        print(limw);
        lim_x = new Vector2(-limw.x, limw.x);
        lim_y = new Vector2(-limw.y, limw.y);

        GenerateItems();
    }

    static string[] nams = new string[5] {
        "Page 1",
        "Page 2", 
        "Trap", 
        "Nothin", 
        "Buff"
    };

    public void OnPlayerSpawn(Transform new_player) {
        isoCamera.player = new_player;
        isoCamera.players.Add(new_player);
        players.Add(new_player.GetComponent<Player>());
    }

    void GenerateItems() {
        var itemQueue = new ShufflerQueue<Tile>(mapController.map);
        itemDict = new Dictionary<Vector2Int, ItemPickup>();
        for (int i = 0; i < items; i++) {
            CreateItem(itemQueue.next, i);
        }
    }

    void CreateItem(Tile tile, int i=0) {        
        var inst = Instantiate(prefab);
        inst.pos = tile.pos;
        inst.coord = tile.coord;
        inst.gameObject.SetActive(true);
        inst.name = nams[i];
        itemDict.Add(tile.coord, inst);
        inst.transform.SetParent(transform);
    }

    public ItemPickup AttemptGrabItem(Vector2Int c) {
        if (!itemDict.ContainsKey(c)) return null;

        var item = itemDict[c];
        itemDict.Remove(c);

        return item;
    }

    public void RestartGame() {

    }

    public void ShowWinner(Player player) {
        winPanel.SetActive(true);
        var txt = winPanel.GetComponentInChildren<TMP_Text>();
        txt.text = "";
    }
}
