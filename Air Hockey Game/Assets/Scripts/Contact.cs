using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{

	public new Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();

	}


	void OnCollisionEnter(Collision col)
	{
		
		//TODO: Is this the best way to find a collision with the player?
		//FIXME: Make a separate game border contact component as well. Maybe use different layers for game boarder, puck, and player?
		if(col.collider.name == "Player")
		{
			Vector3 impulse = col.impulse / Time.deltaTime;

			//Vector3 impulse = new Vector3(0f,0,100f);

			rigidbody.AddForce(impulse, ForceMode.Acceleration);
			Debug.Log("Impulse: " + impulse);

		}

	}
	


}
