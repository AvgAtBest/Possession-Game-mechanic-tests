using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    #region References
    [Header("References")]
    public Transform target;
    public NavMeshAgent agent;
    public GameObject gun;
    public GameObject player;
    public Transform muzzle;
    public BulletC bulletC;
    public GameObject bullet;
    public HealthController pHealth;
    public EnemyHealth eHealth;

    #endregion
    #region AI Combat
    [Header("AI Combat")]
    public float maxLookDistance = 100f;
    public float maxAttackDistance = 100f;
    public float timer;
    public float shotCounter = 1f;
    public float timeBetweenShots = 0.5f;
    public float distToTarget = 100f;
    public float mSpeed = 5f;
    #endregion
    public void Start()
    {
        player = GameObject.Find("Controller");
        target = player.GetComponent<Transform>();
        pHealth = player.GetComponent<HealthController>();
        eHealth = GetComponent<EnemyHealth>();
    }


    public void Update()
    {
        timer += Time.deltaTime;
        distToTarget = Vector3.Distance(target.position, transform.position);
        if (eHealth.enemyCuHP > 0  && pHealth.sCurHealth > 0)
        {
            agent.SetDestination(target.position);

            bool isCloseToTarget = distToTarget <= maxAttackDistance;
            bool isAllowedToFire = timer >= timeBetweenShots;
            bool isNotDead = pHealth.sCurHealth > 0 || pHealth.pCurHealth > 0;

            if (isCloseToTarget && isAllowedToFire && isNotDead)
            {
                Shoot();
            }
        }
    }
    public void Shoot()
    {
        timer = 0f;
        shotCounter -= Time.deltaTime;
        shotCounter = timeBetweenShots;
        GameObject clone = Instantiate(bullet, muzzle.position, muzzle.rotation);
        BulletC newBullet = clone.GetComponent<BulletC>(); //(target.position - transform.position).normalized, Quaternion.LookRotation(target.position - transform.position));
        newBullet.Fire(transform.forward);
        Debug.Log("Attack");
    }
}