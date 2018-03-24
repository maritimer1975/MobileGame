using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputByKeyboard))]
[RequireComponent(typeof(Rigidbody))]
public class MovementByForce : MonoBehaviour {

	[Tooltip("Select how fast the gameobject reaches maximum force.")]

	
	[SerializeField] public float forceMultiplier = 10f;  // how fast to reach maximum force

	[Tooltip("The maximum force the gameobject will reach.")]
	[SerializeField] public float maxForce = 15f;
	private new Rigidbody rigidbody;
	private PlayerInputByKeyboard playerInput;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		playerInput = GetComponent<PlayerInputByKeyboard>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		string debugText = ": : : : MovementByForce->FixedUpdate() : : : :";

		Vector3 movement = playerInput.Movement;

		for(int i = 0; i <= 2;i++)
			movement[i] *= forceMultiplier;

		movement = Vector3.ClampMagnitude(movement, maxForce);

		rigidbody.AddForce(movement,ForceMode.Acceleration);

		debugText+= "\n    PlayerInput.Movement: " + movement.ToString();

		//Debug.Log(debugText);

	}
}
