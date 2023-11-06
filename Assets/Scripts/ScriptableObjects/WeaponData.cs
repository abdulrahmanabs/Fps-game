using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/gun")]
public class WeaponData : ScriptableObject
{
    [Header("Info")]
    public new string name;
    [Header("Shooting")]
    public float damage;
    public float maxDistance;
    [Header("Reloading")]
    public float fireRate;
    public float currentAmmo;
    public float maxAmmo;
    public float reloadTime;
    public bool isReloading;

}
