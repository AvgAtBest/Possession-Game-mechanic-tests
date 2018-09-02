using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool isFiring;
    public BulletController bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;
    public Transform firePoint;
    public EnemyHealth enemyH;
    public int bDamage = 20;

    GameObject enemy;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyH = enemy.GetComponent<EnemyHealth>();
    }


    void FixedUpdate()
    {
        if (isFiring)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            shotCounter = timeBetweenShots;
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.bSpeed = bulletSpeed;
        }
        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log("Skrat skrat");
            if (hit.collider.name == "Enemy")
            {
                enemyH.TakeDamage(bDamage);
            }
        }
        else
        {
            shotCounter = 0;
        }  
    }
}
