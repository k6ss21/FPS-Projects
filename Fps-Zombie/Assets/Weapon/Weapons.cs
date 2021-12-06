using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 20f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffects;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] Ammotype ammotype;

    [SerializeField] float timeBetweenShots = .5f;

    bool canShoot = true;

    void OnEnable()
    {
        FPCamera.fieldOfView =60f;
        canShoot = true;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {

            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammotype) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.reduceCurrentAmmo(ammotype);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            //  Debug.Log("Ihit " + hit.transform.name);
            CreateHitImpact(hit);
            //Debug.Log("Hit pos"+ hit.point);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }

            target.TakeDamage(damage);
        }
        else { return; }
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
    void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffects, hit.point, Quaternion.LookRotation(hit.normal));
        //  Debug.Log("Impact ppos" + impact.transform.position);
        Destroy(impact, .1f);
    }
}
