using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMonster : Monster
{
    private void Awake()
    {
        monsterType = MonsterType.Straight;
    }

    [Header("Move Setting")]
    public Vector2 direction;
    public float speed;
    public float switchTime;

    Coroutine moving;

    private void Start()
    {
        moving = StartCoroutine(MoveStraight());
    }

    public override void BeforeDestroy()
    {
        StopCoroutine(moving);
    }

    IEnumerator MoveStraight()
    {
        float time = Time.time;
        Vector2 _dir = direction;
        while (true)
        {
            while (time + switchTime > Time.time)
            {
                transform.position += new Vector3(_dir.x, _dir.y) * speed * Time.deltaTime;
                yield return null;
            }
            time = Time.time;
            _dir *= -1;
        }
    }
}
