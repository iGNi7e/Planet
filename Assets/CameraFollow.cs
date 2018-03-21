using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothness = 1f;
    public float rotationSmoothness = 0.1f;

    public Vector3 offset = new Vector3(0f,13f,0f);
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        Vector3 newPos = target.TransformDirection(offset);
        //Debug.Log(newPos);
        transform.position = Vector3.SmoothDamp(transform.position,newPos,ref velocity,smoothness);
        //transform.LookAt(target);
        Quaternion targetRot = Quaternion.LookRotation(-transform.position.normalized,target.up);

        transform.rotation = Quaternion.Lerp(transform.rotation,targetRot,Time.deltaTime * rotationSmoothness);
    }
}
