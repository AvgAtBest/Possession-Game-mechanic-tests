using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletC : MonoBehaviour
{
    public int damage = 10;
    public Rigidbody bRigid;
    public float bSpeed = 25f;
    public HealthController playerH;
    // Use this for initialization
    public void Fire(Vector3 direction)
    {
        bRigid.AddForce(direction * bSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerH = GameObject.Find("Controller").GetComponent<HealthController>();
            playerH.TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log("Die, die, die!");
        }
        //if(other.gameObject.tag != "Player" && other.gameObject.tag != "Enemy")
        if (other.gameObject.tag != "Player" && other.gameObject != this.gameObject)
        {
            Destroy(gameObject, 2);
        }
    }
}
