using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float range = 7f;
    public float fireRate = 0.75f;
    public float damage = 50f;

    public Camera fpsCam;
    public GameObject ImpactEffect;
    public Animator animator;

    private float nextTimeToFire;


    void Start()
    {
        
    }

 
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Slice();
        }
    }
    void Slice()
    {
        animator.SetBool("Slice", true);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {   
            Zombie target = hit.transform.GetComponent<Zombie>();
            if (target != null)
            {
                target.TakeDamege(damage);
            }

            GameObject BulletEffect = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(BulletEffect, 2f);
        }

        Invoke("StopAnimation", 0.5f);
    }

    void StopAnimation ()
    {
        animator.SetBool("Slice", false);
        print("false");
    }
}
