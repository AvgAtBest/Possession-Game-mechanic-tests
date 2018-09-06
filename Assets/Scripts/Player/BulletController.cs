using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bSpeed = 2f;
    public GameObject enemy;
    public EnemyHealth enemyH;
    public int bDamage = 5;
    public Rigidbody bRigid;
    // Use this for initialization
    public void Fire(Vector3 direction)
    {
        bRigid.AddForce(direction * bSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * bSpeed * Time.deltaTime);
        Destroy(gameObject, 2);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Fuck");
            enemy = other.gameObject;
            enemyH = enemy.GetComponentInChildren<EnemyHealth>();
            enemyH.TakeDamage(bDamage);

        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
        
    }
}