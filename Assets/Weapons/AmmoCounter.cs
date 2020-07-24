using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    public GameObject AmmoTextMesh; 
    public string currentAmmoOnGun;
    public string ammoOwnForGun;


    void Start()
    {
       
    }


    void Update()
    {
        if (FindObjectOfType<Weapon_Switching>().selectedWeapon == 0)
        {
            currentAmmoOnGun = FindObjectOfType<Gun_AK47>().currentAmmo.ToString();
            ammoOwnForGun = FindObjectOfType<Gun_AK47>().ammoOwn.ToString();
            AmmoTextMesh.GetComponent<TMPro.TextMeshProUGUI>().text = currentAmmoOnGun + " / " + ammoOwnForGun;
        }
        else if (FindObjectOfType<Weapon_Switching>().selectedWeapon == 1)
        {
            currentAmmoOnGun = FindObjectOfType<Gun_Pistol>().currentAmmo.ToString();
            ammoOwnForGun = FindObjectOfType<Gun_Pistol>().ammoOwn.ToString();
            AmmoTextMesh.GetComponent<TMPro.TextMeshProUGUI>().text = currentAmmoOnGun + " / " + ammoOwnForGun;
        }
        else if (FindObjectOfType<Weapon_Switching>().selectedWeapon == 2)
        {
            AmmoTextMesh.GetComponent<TMPro.TextMeshProUGUI>().text = "Infinite";
        }
     

   }
}
