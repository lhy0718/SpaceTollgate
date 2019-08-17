using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingManager : MonoBehaviour
{
    private PlayerController player;

    void Awake() {

    }
    void Start() {
        player = GameManager.instance.player;
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Enemy") {
            player.rigidbody.AddForce(player.transform.TransformVector(new Vector2(0,-1)), ForceMode2D.Impulse);
            player.Hp -= 10;
        }
    }
}
