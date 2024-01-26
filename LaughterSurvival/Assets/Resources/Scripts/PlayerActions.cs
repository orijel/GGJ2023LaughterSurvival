using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private WeaponsManager weaponsManager;

    public void Attack()
    {
        var activeWeapon = weaponsManager.ActiveWeapon;
        if (activeWeapon == null)
        {
            return;
        }

        activeWeapon.Attack();
    }

    private void StopAttack()
    {
        var activeWeapon = weaponsManager.ActiveWeapon;
        if (activeWeapon == null)
        {
            return;
        }

        activeWeapon.StopAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Attack();
        }

        if(Input.GetKeyUp(KeyCode.V))
        {
            StopAttack();
        }

        // TODO: delete this code after checking gun
        if (Input.GetKeyDown(KeyCode.T))
        {
            weaponsManager.ActivateWeapon("FartGun");
        }
    }
}
