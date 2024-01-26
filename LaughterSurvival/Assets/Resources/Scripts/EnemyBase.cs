using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{

    public float enemyHealth = 100f;

    public void OnDamageTaken(WeaponBase weapon)
    {
        Debug.Log($"Taking damage from: {weapon.name}");
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
