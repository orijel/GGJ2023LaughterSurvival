using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FartGun : WeaponBase
{

    private AudioSource audioSource;


    private static int ShootAnimatorHash = Animator.StringToHash("Shoot");

    [SerializeField] private float _attackTick = 0.3f;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _vfx;

    private IList<EnemyBase> _enemeiesInRange = new List<EnemyBase>();
    private Coroutine _attackCoroutine;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        _animator.SetTrigger(ShootAnimatorHash);
        _attackCoroutine = this.ActivateWithDelay(TryDamageEnemy, _attackTick);

    }

    public void StopVfx()
    {
        _vfx.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void CancelAttack()
    {
        _enemeiesInRange.Clear();
        StopCoroutine(_attackCoroutine);
    }

    public void DamageEnemyByCollider(Collider other)
    {
        EnemyBase enemyBase = other.GetComponent<EnemyBase>();
        if (enemyBase == null)
        {
            return;
        }
        _enemeiesInRange.Add(enemyBase);
    }

    public void RemoveEnemyFromCollider(Collider other)
    {
        EnemyBase enemyBase = other.GetComponent<EnemyBase>();
        if (enemyBase == null)
        {
            return;
        }
        _enemeiesInRange.Remove(enemyBase);
    }

    private void TryDamageEnemy()
    {
        PlayRandomAudio("Farts");

        foreach (var enemy in _enemeiesInRange)
        {
            HitEnemey(enemy);
        }
        _enemeiesInRange = _enemeiesInRange.Where(x => x.EnemyHealth > 0).ToList();
        _attackCoroutine = this.ActivateWithDelay(TryDamageEnemy, _attackTick);
    }

    void PlayRandomAudio(string which)
    {
        AudioClip[] audioClips = Resources.LoadAll<AudioClip>("Sounds/SFX/"+which);

        if (audioClips.Length > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, audioClips.Length);
            AudioClip randomClip = audioClips[randomIndex];

            // Assign the randomly selected audio clip to the AudioSource component
            audioSource.clip = randomClip;

            // Play the assigned audio clip
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No audio clips found in the specified folder: " + "Sounds/SFX/Laughs");
        }
    }
}
