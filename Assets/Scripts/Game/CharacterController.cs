using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour {
    public Vector2 lim_x;
    public Vector2 lim_y;
    
    //ControlMap controlMap;
    public float speed = 1.0f;

    public Vector2 vel;
    public enum PlayerType {
        Player1 = 0,
        Player2 = 1,
    }

    public PlayerType playerType;
    PlayerInput playerInput;
    public Vector2 pos {
        get => new Vector2(transform.localPosition.x, transform.localPosition.z);
        set => transform.localPosition = new Vector3(value.x, transform.localPosition.y, value.y);
    }
    private void Awake() {
        //controlMap = new ControlMap();
        //controlMap.Enable();

        playerInput = GetComponent<PlayerInput>();
        //playerInput.actionEvents
    }
    public Transform player;
    void Start() {
        var cont = GameManager.instance;
        lim_x = cont.lim_x;
        lim_y = cont.lim_y;

        cont.OnPlayerSpawn(transform);

        //var player = controlMap.Player;
        //player.Move.performed += 
        //    ctx => Move(ctx.ReadValue<Vector2>());

        //player.Move.canceled +=
        //    ctx => Move(ctx.ReadValue<Vector2>());
    }

    public void MoveCallback(InputAction.CallbackContext ctx) {
        Move(ctx.ReadValue<Vector2>());
    }

    void Move(Vector2 m) {
        vel = m;
    }

    private void FixedUpdate() {
        var npos = pos;
        npos += Time.deltaTime * speed * vel;

        npos.x = Mathf.Clamp(npos.x, lim_x.x, lim_x.y);
        npos.y = Mathf.Clamp(npos.y, lim_y.x, lim_y.y);

        pos = npos;
    }
}
