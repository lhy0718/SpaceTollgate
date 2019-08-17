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
    public float range;

    [SerializeField]
    private int shieldLevel;
    [SerializeField]
    private int rangeLevel;
    [SerializeField]
    private int speedLevel;
    public int ShieldLevel {
        get {
            return shieldLevel;
        }
        set {
            shieldLevel = value;
            maxHp += 1;
        }
    }

    public int RangeLevel
    {
        get
        {
            return rangeLevel;
        }
        set
        {
            rangeLevel = value;
            range += 2.5f;
        }
    }

    public int SpeedLevel
    {
        get
        {
            return speedLevel;
        }
        set
        {
            speedLevel = value;
            //test: temp value
            speed += 2;
        }
    }

    private WingManager rWingM, lWingM;
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

    private void Start()
    {
        lWingM = lWing.GetComponent<WingManager>();
        rWingM = rWing.GetComponent<WingManager>();
    }

    void Update() {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift)) {
            rigidbody.AddForce(transform.TransformVector(new Vector2(0, vertical * boostSpeed)));
        } else {
            rigidbody.AddForce(transform.TransformVector(new Vector2(0, vertical * speed)));
        }
        rigidbody.AddTorque(-horizontal * rotateSpeed);

        if (vertical > 0)
        {
            if (horizontal < 0)
            {
                rWingM.frontBurst.SetActive(true);
                rWingM.backBurst.SetActive(true);
                lWingM.frontBurst.SetActive(true);
                lWingM.backBurst.SetActive(false);
            }
            else if (horizontal > 0)
            {
                rWingM.frontBurst.SetActive(true);
                rWingM.backBurst.SetActive(false);
                lWingM.frontBurst.SetActive(true);
                lWingM.backBurst.SetActive(true);
            }
            else
            {
                rWingM.frontBurst.SetActive(true);
                rWingM.backBurst.SetActive(false);
                lWingM.frontBurst.SetActive(true);
                lWingM.backBurst.SetActive(false);
            }
        }
        else if (vertical < 0)
        {
            if (horizontal < 0)
            {
                rWingM.frontBurst.SetActive(true);
                rWingM.backBurst.SetActive(true);
                lWingM.frontBurst.SetActive(false);
                lWingM.backBurst.SetActive(true);
            }
            else if (horizontal > 0)
            {
                rWingM.frontBurst.SetActive(false);
                rWingM.backBurst.SetActive(true);
                lWingM.frontBurst.SetActive(true);
                lWingM.backBurst.SetActive(true);
            }
            else
            {
                rWingM.frontBurst.SetActive(false);
                rWingM.backBurst.SetActive(true);
                lWingM.frontBurst.SetActive(false);
                lWingM.backBurst.SetActive(true);
            }
        }
        else
        {
            if (horizontal < 0)
            {
                rWingM.frontBurst.SetActive(true);
                rWingM.backBurst.SetActive(false);
                lWingM.frontBurst.SetActive(false);
                lWingM.backBurst.SetActive(true);
            }
            else if (horizontal > 0)
            {
                rWingM.frontBurst.SetActive(false);
                rWingM.backBurst.SetActive(true);
                lWingM.frontBurst.SetActive(true);
                lWingM.backBurst.SetActive(false);
            }
            else
            {
                rWingM.frontBurst.SetActive(false);
                rWingM.backBurst.SetActive(false);
                lWingM.frontBurst.SetActive(false);
                lWingM.backBurst.SetActive(false);
            }
        }
    }
}
