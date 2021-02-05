using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;

    [SerializeField] private float fireRate;
    [SerializeField] private float pauseTime;
    private float pauseTimeCounter;
    [SerializeField] private int shootCounter;
    private int shootCounterCounter;
    private float fireRateCounter;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject firePointParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnUpdate(bool isStarted)
    {
        if (isStarted)
        {
            if (fireRateCounter > 0)
            {
                fireRateCounter -= Time.deltaTime;
            }

            if (fireRateCounter <= 0)
            {
                Shoot();
            }

            if (pauseTimeCounter > 0)
            {
                pauseTimeCounter -= Time.deltaTime;
            }
        }
    }

    private void Shoot()
    {
        if (pauseTimeCounter <= 0)
        {
            fireRateCounter = fireRate;
            Instantiate(firePointParticle, firePoint.position, firePoint.rotation);
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            shootCounterCounter++;
            if (shootCounterCounter >= shootCounter)
            {
                shootCounterCounter = 0;
                pauseTimeCounter = pauseTime;
            }     
        }
    }
}
