using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputByKeyboard : MonoBehaviour {
	
	public Vector3 Movement
	{
		get;
		set;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");
		
		Movement = new Vector3(hAxis, 0, vAxis);
	}
}
