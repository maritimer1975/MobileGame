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

			Vector3 impulse = col.impulse / Time.deltaTime;

			//Vector3 velocity = col.relativeVelocity;

			debugText += "\n    Initial Impulse: " + impulse;
			debugText += "\n    Bounce Factor: " + bounceFactor;
			debugText += "\n    Max Bounce: " + maxBounce;

			//debugText+= "\n    Initial Relative Velocity: " + impulse;
			//FIXME: When bouncing on left / right the z direction is not working properly. 
			switch (borderSide)
			{
				case "left":
				case "right":
					impulse.x = impulse.x * bounceFactor;
					impulse.z *= bounceFactor;
					debugText += "\n    Contact with side: " + borderSide;
					break;

				case "top":
				case "bottom":
					impulse.z = impulse.z * bounceFactor;
					impulse.x *= bounceFactor;
					debugText += "\n    Contact with side: " + borderSide;
					break;

				default:
					break;
			}

			
			impulse = Vector3.ClampMagnitude(impulse, maxBounce);

			col.gameObject.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
			
			debugText += "\n    Bounced Relative impulse: " + impulse;

			Debug.Log(debugText);

		}
	}
}
