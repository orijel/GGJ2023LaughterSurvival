using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{

    public float EnemyHealth = 100;

    public virtual void OnDamageTaken(WeaponBase weapon)
    {
        Debug.Log($"Taking damage from: {weapon.name}");
        if ( EnemyHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        throw new NotImplementedException();
    }

    public void onAttack()
    {

    }

    public void onAttackSuccess()
    {
        // TODO: implement this
        //Debug.Log($"Taking damage from: {weapon.name}");
    }

    protected Vector3 GetTarget(string tag)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
        float currentClosestDistance = float.PositiveInfinity;
        GameObject currentClosest = this.gameObject;
        foreach (GameObject target in targets)
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) < currentClosestDistance)
            {
                currentClosest = target;
            }
        }
        return currentClosest.transform.position;
    }

    protected Vector3 GetTarget(Transform target)
    {
        return target.position;
    }

    protected NavMeshAgent InitializeNavMeshAgent()
    {
        NavMeshAgent navMeshAgent;
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        NavMeshHit hit;
        NavMesh.SamplePosition(transform.position, out hit, 100, NavMesh.AllAreas);
        navMeshAgent.Warp(hit.position);
        return navMeshAgent;
    }
}
