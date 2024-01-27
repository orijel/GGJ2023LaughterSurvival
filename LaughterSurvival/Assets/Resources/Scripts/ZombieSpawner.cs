using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : Spawner
{
    protected override void ResetOnSpawn(GameObject obj, Transform transformToInit)
    {
        base.ResetOnSpawn(obj, transformToInit);
        EnemyBase enemyBase = obj.GetComponent<EnemyBase>();
        enemyBase.ResetEnemy();
    }
}
