using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    //public Vector3 mousePos;
    //public float lastAngle;
    // Use this for initialization
    void Start ()
    {
        transform.SetParent(target);
        target = GameObject.Find("Controller").GetComponent<Transform>();
        offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = target.position + offset;
        //mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z - transform.position.z));
        //transform.LookAt(mousePos);
    }
}
