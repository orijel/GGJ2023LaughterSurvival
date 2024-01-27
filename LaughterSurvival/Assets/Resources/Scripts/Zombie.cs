using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : EnemyBase
{
    [SerializeField] private int startHealth = 100;
    [SerializeField] public int Damaage = 100;
    [SerializeField] private GameObject documents;

    private void OnEnable()
    {
        SetHealth(startHealth);
    }

    public override void OnDamageTaken(WeaponBase weapon)
    {
        switch (weapon)
        {
            case FartGun:
            case BaseGun:
                SetHealth(EnemyHealth - weapon.Damage);
                base.OnDamageTaken(weapon);
                break;
            default:
                break;
        }
    }

    protected override void Die()
    {
        gameObject.SetActive(false);
        base.Die();
    }


    public override void OnAttackSuccess()
    {
        //Play animation
        GameObject documentInstance = Instantiate(documents, transform.GetChild(0).transform);
        //documentInstance.transform.LookAt(Vector3.up);
        //documentInstance.transform.position += documentInstance.transform.forward;

    }
}
