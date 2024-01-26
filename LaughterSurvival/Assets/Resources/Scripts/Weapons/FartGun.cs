using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartGun : WeaponBase
{
    private static int ShootAnimatorHash = Animator.StringToHash("Shoot");

    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _vfx;

    public void Shoot()
    {
        _animator.SetTrigger(ShootAnimatorHash);
    }

    public void StopVfx()
    {
        _vfx.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
}
