using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private EnemyBase _enemyBase;
    [SerializeField] private SpriteMask _spriteMask;
    [SerializeField] private float _animDuration = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        _spriteMask.gameObject.transform.localScale = Vector3.one;
    }

    public void SetHealth(float currentHealth, float maximumHealth)
    {
        var ratio = currentHealth / maximumHealth;
        var clampedRatio = ratio > 0 ? ratio : 0;
        _spriteMask.transform.DOScaleX(clampedRatio, _animDuration);
    }
}
