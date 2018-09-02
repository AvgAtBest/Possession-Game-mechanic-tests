using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyMaxHP;
    public float enemyCuHP;
    public int damage = 30;
	void Start ()
    {
        enemyMaxHP = 100f;
        enemyCuHP = 100f;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (enemyCuHP <= 0)
        {
            Destroy(gameObject);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        enemyCuHP -= damage;

    }
}
