using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayMonster : Monster
{
    public override void BeforeDestroy()
    {
        return;
    }

    private void Awake()
    {
        monsterType = MonsterType.Stay;
    }
}
