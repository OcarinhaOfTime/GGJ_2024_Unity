using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
    public Vector2 pos {
        get => new Vector2(transform.localPosition.x, transform.localPosition.z);
        set => transform.localPosition = new Vector3(value.x, transform.localPosition.y, value.y);
    }

    public Vector2 coord;

    public enum ItemPickupType {
        Nothing,
        Trap,
        Buff,
        Page
    }

    public ItemPickupType pickupType;
}
