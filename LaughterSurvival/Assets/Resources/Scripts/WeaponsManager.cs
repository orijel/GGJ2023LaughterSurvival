using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponsManager : MonoBehaviour
{
	[SerializeField] private WeaponBase[] _weapons;

	public WeaponBase ActiveWeapon { get; private set; }

	private void Start()
	{
		EquipWeapon("baseGun");
	}
    public void EquipWeapon(string id)
    {
        WeaponBase weapon = _weapons.First(weapon => weapon.WeaponId == id);
        weapon.IsEquiped = true;
        ActivateWeapon(weapon.WeaponId);

    }
    private void ActivateWeapon(string id)
	{
		WeaponBase weapon = _weapons.First(weapon => weapon.WeaponId == id);
		ActiveWeapon?.Deactivate();
		weapon.Activate();
		ActiveWeapon = weapon;
	}

	public void ActivateNextWeapon() {
        if (_weapons == null || _weapons.Length == 0)
        {
            Debug.LogWarning("No weapons available to equip.");
            return;
        }

        // If ActiveWeapon is null, equip the first weapon and return
        if (ActiveWeapon == null)
        {
            ActivateWeapon(_weapons[0].WeaponId);
            return;
        }

        // Find the index of the active weapon
        int activeWeaponIndex = System.Array.IndexOf(_weapons, ActiveWeapon);

        // If the active weapon is found in the array, equip the next weapon
        if (activeWeaponIndex != -1)
        {
            var equipedWeapons = _weapons.Where(x => x.IsEquiped).ToList();
            // Calculate the index of the next weapon using modulo to wrap around
            int nextWeaponIndex = (activeWeaponIndex + 1) % equipedWeapons.Count;

            // Activate the next weapon
            ActivateWeapon(equipedWeapons[nextWeaponIndex].WeaponId);
        }
    }
}