using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : WeaponBase
{
	[SerializeField] private ObjectPool myProjectilePool;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			ShootProjectile();
		}
	}

	private void ShootProjectile()
	{
		for (int i = 0; i < myProjectilePool.pool.Length; i++)
		{
			if (myProjectilePool.pool[i].activeInHierarchy == false)
			{
				myProjectilePool.pool[i].transform.position = transform.position;
				myProjectilePool.pool[i].SetActive(true);
				myProjectilePool.pool[i].GetComponent<Rigidbody>()
					.AddRelativeForce(Vector3.forward * 100f, ForceMode.Impulse);
				return;
			}
		}
	}
}