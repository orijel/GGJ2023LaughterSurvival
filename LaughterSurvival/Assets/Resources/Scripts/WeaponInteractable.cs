using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteractable : MonoBehaviour
{
    [SerializeField] public GameObject weapon;
    [SerializeField] public string weaponId;
    
    public void Equip()
    {
        GlobalGameManager.Instance.Player.WeaponsManager.ActivateWeapon(weaponId);
        weapon.SetActive(false);
    }
}
