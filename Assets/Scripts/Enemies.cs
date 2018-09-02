using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public float speed;

    private float distToTarget;
    GameObject detectedPlayer;
    bool playerInRange;
    float timer;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    private void Update()
    {
        Seek();
    }

    void Seek()
    {
        agent.SetDestination(target.position);
    }
}
