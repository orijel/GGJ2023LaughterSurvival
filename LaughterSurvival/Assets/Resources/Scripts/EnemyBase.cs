using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public void OnHit(WeaponBase weapon)
    {
        // TODO: implement this
        Debug.Log($"Taking damage from: {weapon.name}");
    }
}
