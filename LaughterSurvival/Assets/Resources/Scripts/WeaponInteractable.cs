using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteractable : MonoBehaviour
{
    [SerializeField] public GameObject weapon;
    public void Equip()
    {
        GlobalGameManager.Instance.Player.WeaponsManager.ActivateWeapon("FartGun");
        weapon.SetActive(false);
    }
}
