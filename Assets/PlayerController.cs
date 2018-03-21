using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float rotationSpeed = 100f;

    public Rigidbody rb;

    float rotation;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rotation = Input.GetAxisRaw("Horizontal");
	}

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * speed * Time.fixedDeltaTime);
        Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation,targetRotation,50f * Time.deltaTime));
    }
}
