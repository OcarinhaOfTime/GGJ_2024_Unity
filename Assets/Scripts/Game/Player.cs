using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    MapController mapController;
    GameManager gameManager;
    public List<ItemPickup> items = new List<ItemPickup>();
    public Vector2 pos {
        get => new Vector2(transform.localPosition.x, transform.localPosition.z);
        set => transform.localPosition = new Vector3(value.x, transform.localPosition.y, value.y);
    }

    public Vector2Int coord;

    private void Start() {
        mapController = MapController.instance;
        gameManager = GameManager.instance;
    }

    private void Update() {
        var ncoord = mapController.map.WorldPointToCoord(pos);
        if(ncoord != coord) {
            coord = ncoord;
            OnCoordChange();
        }
    }

    void OnCoordChange() {
        var item = gameManager.AttemptGrabItem(coord);
        if (item == null) return;

        GrabPickup(item);

        items.Add(item);
        item.gameObject.SetActive(false);
    }

    public void GrabPickup(ItemPickup item) {
        switch (item.pickupType) {
            case ItemPickup.ItemPickupType.Trap:
                print("We debuff");
                break;

            case ItemPickup.ItemPickupType.Buff:
                print("We buffing");
                break;

            case ItemPickup.ItemPickupType.Page:
                print("We found a page");
                break;

            default:
                print("Nothing");
                break;
        }

    }
}
