using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseGun : WeaponBase
{
	[SerializeField] private ObjectPool _myProjectilePool;
	[SerializeField] private float _projectileSpeed = 5f;
	[SerializeField] private ForceMode _forceMode;
	private LayerMask groundMask;
	[SerializeField] private float groundOffset = 1;

	public void ShootProjectile()
	{
		for (int i = 0; i < _myProjectilePool.pool.Length; i++)
		{
			if (_myProjectilePool.pool[i].activeInHierarchy == false)
			{
				_myProjectilePool.pool[i].transform.position = transform.position;
				_myProjectilePool.pool[i].SetActive(true);
				_myProjectilePool.pool[i].GetComponent<Rigidbody>()
					.AddForce(GetShootDir() * _projectileSpeed, _forceMode);
				return;
			}
		}
	}

	private Vector3 GetShootDir()
	{
		return (GetMouseWorldLocation() - transform.position);
	}

	private Vector3 GetMouseWorldLocation()
	{
		RaycastHit raycastHit;
		Vector3 targetPos = new Vector3();
		Ray ray = GetMouseRay();
		if (Physics.Raycast(ray, out raycastHit, 1000, groundMask))
		{
			targetPos = raycastHit.point + ray.direction * groundOffset / ray.direction.y;
		}

		return (transform.position - targetPos);
	}

	private static Ray GetMouseRay()
	{
		return Camera.main.ScreenPointToRay(Input.mousePosition);
	}
}