using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public float mSpeed = 2.75f;
    public float timeBetweenAttacks = 2.5f;
    public int damage = 10;
    public float attackRadius = 1f;
    public float seekRadius = 5f;
    HealthController pHealth;
    EnemyHealth eHealth;
    private float distToTarget;
    private float timer;
    void Start ()
    {
        target = GameObject.Find("Controller").GetComponent<Transform>();
        pHealth = GameObject.Find("Controller").GetComponent<HealthController>();
        eHealth = GameObject.Find("Enemy").GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.SetDestination(target.position);
        //distToTarget = Vector3.Distance(transform.position, target.position);
        //if (distToTarget < attackRadius && pHealth.sCurHealth > 0 && pHealth.pCurHealth > 0)
        if (distToTarget <= seekRadius && timer >= timeBetweenAttacks && pHealth.sCurHealth > 0)
        {
            Attack();
        }
    }
    void Attack()
    {
        timer = 0f;
        pHealth.TakeDamage(damage);
    }
}
