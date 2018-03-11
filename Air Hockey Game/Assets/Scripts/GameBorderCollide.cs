using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBorderCollide : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.name == "Player")
		{
			Debug.Log("Game Border Collision with: " + col.name);

			PlayerInput playerInput = col.GetComponent<PlayerInput>();
			playerInput.Movement = new Vector3(0,0,0);
		}
	}

	void OnTriggerStay(Collider col)
	{
		if(col.name == "Player")
		{
			Debug.Log("Game Border Collision with: " + col.name);

			PlayerInput playerInput = col.GetComponent<PlayerInput>();
			//playerInput.Movement = new Vector3(0,0,0);
		}

	}

}
