using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private PlayerController player;
    void Start() {
        player = GameManager.instance.player;
    }
    void Update() {
        if (player != null)
            transform.position = player.transform.position + new Vector3(0, 0, -10);

    }
}
