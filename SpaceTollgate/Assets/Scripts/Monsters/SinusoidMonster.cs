using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidMonster : Monster
{
    private void Awake()
    {
        monsterType = MonsterType.Sinusoid;
    }

    public float moveTime = 3;
    public float mag = 1;

    private Coroutine sinMove;

    private void Start()
    {
        sinMove = StartCoroutine(SinMove());
    }
    public override void BeforeDestroy()
    {
        StopCoroutine(sinMove);
        return;
    }

    float coordinate = 0;
    int direction = 1;
    IEnumerator SinMove()
    {
        float time = Time.time;
        while (true)
        {
            while (time + moveTime > Time.time)
            {
                transform.position = new Vector2(transform.position.x + Time.deltaTime * direction * 3, transform.position.y + mag * (0.4f * Mathf.Sin(coordinate + 0.05f) - 0.4f * Mathf.Sin(coordinate)) / 2);
                coordinate += Time.deltaTime;
                yield return null;
            }
            time = Time.time;
            direction *= -1;
            transform.Rotate(new Vector3(0,0,180));
        }
    }
}
