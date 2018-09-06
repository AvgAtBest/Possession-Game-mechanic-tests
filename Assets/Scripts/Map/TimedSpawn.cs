using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public HealthController playerHealth;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);


    }
        public void SpawnObject()
        {
        if(playerHealth.sCurHealth <= 0f)
        {
            return;
        }
            Instantiate(spawnee, transform.position, transform.rotation);
            if(stopSpawning)
            {
                CancelInvoke("SpawnObject");
            }
        }
        
    


}
