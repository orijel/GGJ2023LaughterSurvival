using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private EnemyBase _enemyBase;
    [SerializeField] private GameObject _healthBarMask;
    [SerializeField] private float _animDuration = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        _healthBarMask.transform.localScale = Vector3.one;
    }

    public void TakeDamage()
    {
        SetHealth(_enemyBase.EnemyHealth, _enemyBase.MaximumHealth);
    }

    private void SetHealth(float currentHealth, float maximumHealth)
    {
        var ratio = currentHealth / maximumHealth;
        var clampedRatio = ratio > 0 ? ratio : 0;
        _healthBarMask.transform.DOScaleX(clampedRatio, _animDuration);
    }
}
