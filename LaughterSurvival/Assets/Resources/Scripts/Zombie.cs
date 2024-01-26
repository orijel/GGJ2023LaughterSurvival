using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : EnemyBase
{
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = InitializeNavMeshAgent();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = GetTarget("Player");
    }

    void OnAttack()
    {

    }

    void OnAttackSuccess()
    {

    }

    public override void OnDamageTaken(WeaponBase weapon)
    {
        if (weapon is FartGun fartGun) {
            EnemyHealth -= fartGun.Damage;
        }

        if (weapon is BaseGun baseGun)
        {
            EnemyHealth -= baseGun.Damage;
        }
        base.OnDamageTaken(weapon);
    }

    protected override void Die()
    {
        gameObject.SetActive(false);
    }
}
