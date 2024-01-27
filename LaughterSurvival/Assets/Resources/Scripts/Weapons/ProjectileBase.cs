using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ProjectileBase : MonoBehaviour
{
	[SerializeField] public WeaponBase myWeapon;
	[SerializeField] private float speed = 2f;
	public ObjectPool myPool;
	private float timeStamp;

	private void OnEnable()
	{
		timeStamp = Time.time;
	}


	private void OnTriggerEnter(Collider other)
	{
		//TODO: get enemy base and deal damage
		// if (other.gameObject.CompareTag("Player")) return;
		if (other.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("(Trigger)EMOTIONAL DAMAGE!! :" + other.gameObject.name);
			EnemyBase enemy = other.gameObject.GetComponent<EnemyBase>();
			if (enemy != null)
			{
				enemy.OnDamageTaken(myWeapon);
			}

			ResetProjectile();
		}
	}

	private void Update()
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
		if (timeStamp + 10f < Time.time)
		{
			ResetProjectile();
		}
	}


	private void ResetProjectile()
	{
		gameObject.SetActive(false);
		transform.parent = myPool.transform;
	}
	
}