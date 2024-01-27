using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    ControlMap controlMap;
    private void Awake() {
        controlMap = new ControlMap();
        controlMap.Enable();
    }

    void Start() {

    }
}
