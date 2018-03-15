using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckController : MonoBehaviour
{

	[Tooltip("Maximum force to apply to the puck.")]
	[SerializeField] public float maxForce = 10f;

	private new Rigidbody rigidbody;

	[SerializeField] public GameBoardDimension boardDimension;

	private Vector3 puckScale;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();

		puckScale = transform.localScale;

	}

	void FixedUpdate()
	{
		/*Vector3 position = transform.position;

		float xMin = -( ( boardDimension.width / 2 ) - ( puckScale.x / 2 ) );
		float xMax = -xMin;
		float zMin = -( ( boardDimension.length / 2) - (puckScale.z / 2 ) );
		float zMax = -zMin;


		if( position.x < xMin )
			position.x = xMin;
		else if( position.x > xMax )
			position.x = xMax;

		if( position.z < zMin )
			position.z = zMin;
		else if ( position.z > zMax )
			position.z = zMax;
		
		rigidbody.MovePosition(position);
		*/
	}


	void OnCollisionEnter(Collision col)
	{
		
		//TODO: Is this the best way to find a collision with the player?
		//FIXME: Make a separate game border contact component as well. Maybe use different layers for game boarder, puck, and player?
		if(col.collider.name == "Player")
		{
			Vector3 impulse = col.impulse / Time.deltaTime;

			//Vector3 impulse = new Vector3(0f,0,100f);

			impulse = Vector3.ClampMagnitude(impulse, maxForce);

			rigidbody.AddForce(impulse, ForceMode.Impulse);
			col.rigidbody.AddForce(Vector3.zero,ForceMode.Force);

		}
	}
}
