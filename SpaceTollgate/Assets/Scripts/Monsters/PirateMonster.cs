using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateMonster : Monster
{
    public override void BeforeDestroy()
    {
        GameManager.instance.deletedMonster = monsterName;
        StopCoroutine(followWing);
    }

    private void Awake()
    {
        monsterType = MonsterType.Pirate;
    }

    public float speed = 1;
    public float detectRadius = 5;

    private Coroutine followWing;

    IEnumerator Follow(Transform wing)
    {
        while (true)
        {
            Vector3 pos = wing.position;
            Vector3 player_pos = transform.position;
            Vector2 mouse_pos = new Vector2(pos.x - player_pos.x, pos.y - player_pos.y);
            float rad = Mathf.Atan2(mouse_pos.x, mouse_pos.y);
            float mouse_rotate = (rad * 180) / Mathf.PI;
            transform.localEulerAngles = new Vector3(0, 0, (mouse_rotate));
            transform.position += (wing.position - transform.position) * speed * Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wing") && followWing == null)
        {
            followWing = StartCoroutine(Follow(col.transform));
        }
    }
}
