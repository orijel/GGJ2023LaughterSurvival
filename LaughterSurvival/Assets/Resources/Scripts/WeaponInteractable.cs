using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteractable : MonoBehaviour
{
    [SerializeField] public GameObject weapon;
    [SerializeField] public string weaponId;
    
    public void Equip()
    {
        GlobalGameManager.Instance.Player.WeaponsManager.EquipWeapon(weaponId);
        weapon.SetActive(false);
    }
}
