using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    Stay,
    Straight,
    Sinusoid,
    Rotation,
    Revolution,
    Pirate
}

public abstract class Monster : MonoBehaviour
{
    public MonsterType monsterType;
    public int point;

    public List<int> isTriggersEnter = new List<int>();
    public int nextIdx = 0;

    public abstract void BeforeDestroy();
    public void CheckToll()
    {
        bool complete = true;
        for (int i = 0; i < isTriggersEnter.Count; i++)
        {
            if (isTriggersEnter[i] <= 0)
            {
                complete = false;
                break;
            }
        }
        if (complete)
        {
            GameManager.instance.Score += point;
            GameManager.instance.monsterCnt[(int)monsterType]++;
            BeforeDestroy();
            Destroy(gameObject);
        }
    }
}
