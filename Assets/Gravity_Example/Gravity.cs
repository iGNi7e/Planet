using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	
	public float force_amount = 10f;
	
	void OnTriggerStay(Collider col)
	{
		//Debug.Log("Collided " + col.name);
		col.GetComponent<Rigidbody>().AddForce((transform.position - col.transform.position).normalized * force_amount, ForceMode.Force);
	}
}
