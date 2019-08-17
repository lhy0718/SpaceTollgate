using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed, rotateSpeed, boostSpeed;
    public GameObject rWing, lWing, gate;
    public new Rigidbody2D rigidbody;
    public Slider hpBar;
    public int Size { get; set; }
    public int maxHp;
    private int hp;
    public int Hp {
        get {
            return hp;
        }
        set {
            hp = value;
            GameManager.instance.hpBar.value = (float)hp / maxHp;
            if (hp <= 0) {
                GameManager.instance.GameOver();
                Destroy(gameObject);
            }
        }
    }
    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            rigidbody.AddForce(transform.TransformVector(new Vector2(0, Input.GetAxisRaw("Vertical") * boostSpeed)));
        } else {
            rigidbody.AddForce(transform.TransformVector(new Vector2(0, Input.GetAxisRaw("Vertical") * speed)));
        }
        rigidbody.AddTorque(-Input.GetAxis("Horizontal") * rotateSpeed);
    }
}
