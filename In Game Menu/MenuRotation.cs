using UnityEngine;
using System.Collections;

public class MenuRotation : MonoBehaviour {

	public float power = 1.0f;
	float xRotation;
	float yRotation;
	float zRotation;
	Quaternion target;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//maybe x and y is enough
		xRotation = Input.GetAxis ("Mouse Y") * power;
		yRotation = Input.GetAxis ("Mouse X") * power;
		zRotation = Input.GetAxis ("Mouse X") * power;
		target = Quaternion.Euler(xRotation, yRotation, 0);

		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime);
	
	}
}
