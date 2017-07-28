using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunData
{
    public string name = "DummyGunName";

    public float damage = 0.0f;
    public float damageMultiplier = 0.0f;
    public float fireRate = 0.0f;
    public float hitForce = 0.0f;

    public int maxAmmo = 0;
    public int currentAmmo = 0;

    public bool isProjectileWeapon = false;
}
