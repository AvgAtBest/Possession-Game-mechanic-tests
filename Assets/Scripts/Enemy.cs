using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public GameObject playerCap;
    public float mSpeed = 2.75f;
    public float timeBetweenAttacks = 2.5f;
    public int damage = 30;
    public float attackRadius = 4f;
    public HealthController pHealth;
    public EnemyHealth eHealth;
    public float distToTarget = 100f;
    private float timer;
    //public RigidBody eRigidBody;
    void Awake ()
    {
        playerCap = GameObject.FindGameObjectWithTag("Player");
        player = playerCap.GetComponent<Transform>();
        pHealth = playerCap.GetComponent<HealthController>();
        eHealth = GetComponent<EnemyHealth>();
        //eRigidBody = GetComponent<RigidBody>();
	}

    void Update()
    {
        timer += Time.deltaTime;
        distToTarget = Vector3.Distance(transform.position, player.position);

        if (eHealth.enemyCuHP > 0 && pHealth.sCurHealth > 0)
        {
            agent.SetDestination(player.position);
            if (distToTarget < attackRadius && timer >= timeBetweenAttacks && pHealth.sCurHealth > 0 && pHealth.pCurHealth > 0)
            {
                Attack();
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerCap)
        {
            Attack();
        }
    }
    void Attack()
    {
        timer = 0f;
        Debug.Log("Attacking!");
        pHealth.TakeDamage(damage);
    }
}
