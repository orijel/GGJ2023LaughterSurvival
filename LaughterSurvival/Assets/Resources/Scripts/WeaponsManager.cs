using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField] private WeaponBase[] _weapons;

    public WeaponBase ActiveWeapon { get; private set; }

    public void ActivateWeapon(string id)
    {
        WeaponBase weapon = _weapons.First(weapon => weapon.WeaponId == id);
        ActiveWeapon?.Deactivate();
        weapon.Activate();
        ActiveWeapon = weapon;
    }
}
