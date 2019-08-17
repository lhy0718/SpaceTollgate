using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMonster : Monster
{
    public bool isClockwise = true;
    public float speed = 1;
    public override void BeforeDestroy()
    {
        return;
    }

    private void Awake()
    {
        monsterType = MonsterType.Rotation;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, speed * (isClockwise ? -1 : 1)));
    }
}
