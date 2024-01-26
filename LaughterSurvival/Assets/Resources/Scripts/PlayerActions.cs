using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private WeaponsManager weaponsManager;
    [SerializeField] private float _AttackCooldown = 1.5f;

    private bool _isShooting = false;

    public void Attack()
    {
        if (_isShooting)
        {
            return;
        }

        _isShooting = true;
        weaponsManager.ActiveWeapon?.Attack();
        this.ActivateWithDelay(OnShootFinished, _AttackCooldown);
    }

    private void OnShootFinished()
    {
        _isShooting = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("got V down");
            Attack();
        }

        // TODO: delete this code after checking gun
        if (Input.GetKeyDown(KeyCode.T))
        {
            weaponsManager.ActivateWeapon("FartGun");
        }
    }
}
