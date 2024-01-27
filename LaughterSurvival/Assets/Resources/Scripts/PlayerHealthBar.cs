using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerProperties _player;

    [SerializeField] private GameObject _healthBarMask;
    [SerializeField] private float _animDuration = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        _healthBarMask.transform.localScale = Vector3.one;
    }

    public void SetHealth()
    {
        SetHealth(_player.playerHealth, _player.maximumHealth);
    }

    private void SetHealth(float currentHealth, float maximumHealth)
    {
        var ratio = currentHealth / maximumHealth;
        var clampedRatio = ratio > 0 ? ratio : 0;
        _healthBarMask.transform.DOScaleX(clampedRatio, _animDuration);
    }
}
