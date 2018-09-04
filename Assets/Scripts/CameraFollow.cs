using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    void Start ()
    {
        transform.SetParent(target);
        target = GameObject.Find("Controller").GetComponent<Transform>();
        offset = transform.position - target.position;
	}
	

	void Update ()
    {
        transform.position = target.position + offset;

    }
}
