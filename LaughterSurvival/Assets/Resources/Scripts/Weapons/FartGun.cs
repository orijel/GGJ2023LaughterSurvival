using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartGun : WeaponBase
{
    private static int ShootAnimatorHash = Animator.StringToHash("Shoot");

    [SerializeField] private Animator _animator;

    public void Shoot()
    {
        _animator.SetTrigger(ShootAnimatorHash);
    }
}
