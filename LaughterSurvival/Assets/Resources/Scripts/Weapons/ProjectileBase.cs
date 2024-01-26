using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		EnemyBase enemyBase = other.gameObject.GetComponent<EnemyBase>();
		if (enemyBase == null)
		{
			return;
		}
		
	}
}