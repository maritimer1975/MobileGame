using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

	[SerializeField] [Range(0,50)]
	public float speed = 18f;

	[SerializeField] public GameBoardDimension boardDimension;

	private PlayerInput playerInput;
	private new Rigidbody rigidbody;

	private Vector3 playerScale;

	// Use this for initialization
	void Start () {
		playerInput = GetComponent<PlayerInput>();
		rigidbody = GetComponent<Rigidbody>();

		playerScale = transform.localScale;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 movement = playerInput.Movement * speed * Time.deltaTime;
		Vector3 newPosition = transform.position + movement;

		float xMin = -( ( boardDimension.width / 2 ) - ( playerScale.x / 2 ) );
		float xMax = -xMin;
		float zMin = -( ( boardDimension.length / 2) - (playerScale.z / 2 ) );
		float zMax = -zMin;


//TODO: Maybe tie stopping movement into triggers on game boarders.

		if( newPosition.x < xMin )
			newPosition.x = xMin;
		else if( newPosition.x > xMax )
			newPosition.x = xMax;

		if( newPosition.z < zMin )
			newPosition.z = zMin;
		else if ( newPosition.z > zMax )
			newPosition.z = zMax;
		
		rigidbody.MovePosition(newPosition);
	}
}
