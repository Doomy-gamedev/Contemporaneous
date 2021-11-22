using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using StarterAssets;
using Cinemachine;


public class ShootManager : MonoBehaviour
{
    public GameObject bullet;
    [Header("Bullet Settting")] 
    public float shootForce, upwardForce;
    [Header("Gun Settting")] 
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;
    [Header("Player Refernce")]
    public Camera fpsCam;
    public Transform attackPoint;
    private StarterAssetsInputs _input;
    [Header("Wand Effect")]
    public GameObject vfxWandEffect;
    
     public bool allowInvoke = true;

    private void Awake()
    {
        
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();
    }
        
       
     private void MyInput()
    {
        
        if (allowButtonHold && _input.IsAttacking())
        {
            shooting = true;
        }
        else if (!allowButtonHold && _input.IsAttacking())
        {
            shooting = true;
            shooting = false;
            
        }
        
            if (_input.IsReloading() && bulletsLeft < magazineSize && !reloading) Reload();
            
            if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

            
            if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
            {
                
                bulletsShot = 0;

                Shoot();
            }
        else
        {
            
            shooting = false;
        }      
    }

    private void Shoot()
    {
        readyToShoot = false;

        
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
        RaycastHit hit;

        
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); 

        
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); 

       
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); 
        
        currentBullet.transform.forward = directionWithSpread.normalized;

        
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

       
        if (vfxWandEffect != null)
            Instantiate(vfxWandEffect, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            
            
        }

        
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime); 
    }
    private void ReloadFinished()
    {
        
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
   

