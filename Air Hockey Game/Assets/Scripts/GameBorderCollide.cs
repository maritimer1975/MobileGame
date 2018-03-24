using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameBorderCollide : MonoBehaviour 
{

	//[SerializeField] Vector3 borderNormal = new Vector3(0,0,0);
	public int bounceFactor = 50;

	[SerializeField] public float maxBounce = 10f;

	public string borderSide = "DefaultBorderSide";

	void OnCollisionEnter(Collision col)
	{
		if(col.collider.name == "Puck")
		{
			string debugText = "Game Border Collision with: " + col.collider.name;

			//Vector3 impulse = col.impulse / Time.deltaTime;

			Vector3 velocity = col.relativeVelocity;

			debugText += "\n    Initial Relative Velocity: " + velocity;
			debugText += "\n    Bounce Factor: " + bounceFactor;
			debugText += "\n    Max Bounce: " + maxBounce;
			debugText += "\n    Contact with side: " + borderSide;
			
			//FIXME: When bouncing on left / right the z direction is not working properly. 
			switch (borderSide)
			{
				case "left":
				case "right":
					velocity.x = -velocity.x * bounceFactor;
					velocity.z *= bounceFactor;
					break;

				case "top":
				case "bottom":
					velocity.z = -velocity.z * bounceFactor;
					velocity.x *= bounceFactor;
					break;

				default:
					break;
			}

			velocity = Vector3.ClampMagnitude(velocity, maxBounce);

			col.gameObject.GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);
			
			debugText += "\n    Bounced Relative impulse: " + velocity;

			Debug.Log(debugText);

		}
	}
}
