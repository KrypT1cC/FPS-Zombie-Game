using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollect : MonoBehaviour
{
    public GameObject box;

    private void OnTriggerEnter(Collider other)
    {
        if (FindObjectOfType<Weapon_Switching>().selectedWeapon == 0)
        {
            FindObjectOfType<Gun_AK47>().ammoOwn = 270;
            FindObjectOfType<Gun_AK47>().currentAmmo = 30;
        }
        else if (FindObjectOfType<Weapon_Switching>().selectedWeapon == 1)
        {
            FindObjectOfType<Gun_Pistol>().ammoOwn = 35;
            FindObjectOfType<Gun_Pistol>().currentAmmo = 7;
        }

        Destroy(box, 1f);
    }
}
