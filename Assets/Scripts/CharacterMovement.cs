using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Player Movement")]
    public Rigidbody pRigid;
    public float sMoveSpeed;
    public float rayDistance = 100f;
    public bool isShadow = true;
    public bool isPossessed;
    public GameObject shadowForm;
    public GameObject enemyForm;
    public Transform enemy;
    //private Transform[] enemies;
    //private int curIndex = 1;
    [Header("Player Mouse")]
    public Camera mainCamera;
    public GunController gunC;
    public HealthController playerHealth;

    public void Start ()
    {
        pRigid = GetComponent<Rigidbody>();
        pRigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
        //enemies = enemyParent.GetComponentsInChildren<Transform>();
        mainCamera = FindObjectOfType<Camera>();
        playerHealth = this.GetComponent<HealthController>();
        //gunC = GameObject.Find("Gun").GetComponent<GunController>();
        gunC = this.GetComponentInChildren<GunController>();

       
	}
    private void OnDrawGizmos()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
    }
    bool isGrounded()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(groundRay, out hit, rayDistance))
        {
            return true;
        }
        return false;
    }
    // Update is called once per frame
    public void Update ()
    {
        float inputH = Input.GetAxis("Horizontal") * sMoveSpeed;
        float inputV = Input.GetAxis("Vertical") * sMoveSpeed;
        Vector3 moveDir = new Vector3(inputH, 0f, inputV) * sMoveSpeed;
        Vector3 force = new Vector3(moveDir.x, pRigid.velocity.y, moveDir.z);
        pRigid.velocity = force;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        //if ray hits object within the world
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
 
        if (isShadow)
        {
            ShadowForm();
        }
        else
        {
            PuppetForm();
        }
    }
    void OnTriggerStay(Collider enemy)
    {
        if(enemy.gameObject.tag == "Enemy" && isShadow)
        {
            if (Input.GetKey(KeyCode.E))
            {
                pRigid.position = enemy.gameObject.transform.position;
                Destroy(enemy.gameObject);
                isShadow = false;
                isPossessed = true;
                Debug.Log("Entered wrong house fool");
            }
            Debug.Log("Lolwhayt");
        }
    }
    public void ShadowForm()
    {
        Debug.Log("Shadow form");
        shadowForm.SetActive(true);
        enemyForm.SetActive(false);
        playerHealth.enabled = true;
        isPossessed = false;
        sMoveSpeed = 3.75f;
        gunC.isFiring = false;
    }
    public void PuppetForm()
    {
        Debug.Log("Enemy form");
        isPossessed = true;
        shadowForm.SetActive(false);
        enemyForm.SetActive(true);
        playerHealth.enabled = true;
        gunC.enabled = true;
        sMoveSpeed = 2.75f;
        if (Input.GetMouseButtonDown(0))
        {
            gunC.isFiring = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            gunC.isFiring = false;
        }
    }
}
