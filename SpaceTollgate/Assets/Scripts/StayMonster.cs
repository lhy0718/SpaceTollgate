using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayMonster : Monster
{
    private void Awake()
    {
        monsterType = MonsterType.Stay;
    }
}
