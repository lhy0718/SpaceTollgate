using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolutionMonster : Monster
{
    public bool isClockwise = true;
    public float angle = 0;
    public float speed = 1;
    public float radius = 3;

    private Vector2 axisPoint;
    private Rigidbody2D rb;
    public override void BeforeDestroy()
    {
        return;
    }

    private void Awake()
    {
        monsterType = MonsterType.Revolution;
    }

    private void Start()
    {
        axisPoint = transform.position;
        transform.position = axisPoint + new Vector2(0, radius);
        transform.RotateAround(axisPoint, new Vector3(0,0,1), angle);
    }

    private void Update()
    {
        transform.RotateAround(axisPoint, new Vector3(0,0,1), Time.deltaTime * speed);
    }
}
