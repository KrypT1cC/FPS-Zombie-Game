
using UnityEngine;
using System.Collections;

public class Gun_Pistol : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 8f;

    public int ammoOwn = 35;
    public int maxAmmo = 7;
    public int currentAmmo;
    public int finalAmmoNeed;
    public float reloadTime = 2.5f;
    public float animationTime = 0.25f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject ImpactEffect;

    private float nextTimeToFire = 0f;

    public Animator animator;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }
      
        if ((currentAmmo <= 0 || Input.GetKey(KeyCode.R)) && ammoOwn > 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        if (currentAmmo > 0)
        {
            yield return new WaitForSeconds(reloadTime - 0.4f - animationTime);
        }
        else
        {
            yield return new WaitForSeconds(reloadTime - animationTime);
        }

        if (ammoOwn - maxAmmo < 0)
        {
            finalAmmoNeed = maxAmmo - currentAmmo;
            currentAmmo += finalAmmoNeed;
            ammoOwn -= finalAmmoNeed;
            if (ammoOwn < 0)
            {
                currentAmmo += ammoOwn;
                ammoOwn = 0;
            }
        }
        else
        {
            finalAmmoNeed = maxAmmo - currentAmmo;
            currentAmmo = maxAmmo;
            ammoOwn -= finalAmmoNeed;
        }

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(animationTime);

        isReloading = false;
    }

    void Shoot()
    {
        currentAmmo--; 

        muzzleFlash.Play();

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

    }
}
