using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    void Update() {
        transform.position = GameManager.instance.player.transform.position + new Vector3(0, 0, -2);
    }
}
