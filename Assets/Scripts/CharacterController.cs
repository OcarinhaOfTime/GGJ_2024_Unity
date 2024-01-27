using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    ControlMap controlMap;
    public float speed = 1.0f;

    public Vector2 vel;
    public Vector2 pos {
        get => new Vector2(transform.localPosition.x, transform.localPosition.z);
        set => transform.localPosition = new Vector3(value.x, transform.localPosition.y, value.y);
    }
    private void Awake() {
        controlMap = new ControlMap();
        controlMap.Enable();
    }

    void Start() {
        controlMap.Player.Move.performed += 
            ctx => Move(ctx.ReadValue<Vector2>());

        controlMap.Player.Move.canceled +=
            ctx => Move(ctx.ReadValue<Vector2>());
    }

    void Move(Vector2 m) {
        vel = m;
    }

    private void FixedUpdate() {
        pos += Time.deltaTime * speed * vel;
    }
}
