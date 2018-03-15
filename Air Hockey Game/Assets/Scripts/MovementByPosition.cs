using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputByKeyboard))]
[RequireComponent(typeof(Rigidbody))]
public class MovementByPosition : MonoBehaviour {

	[SerializeField] [Range(0,50)]
	public float speed = 18f;

	[SerializeField] public GameBoardDimension boardDimension;

	private PlayerInputByKeyboard playerInput;
	private new Rigidbody rigidbody;

	private Vector3 playerScale;

	// Use this for initialization
	void Start () {
		playerInput = GetComponent<PlayerInputByKeyboard>();
		rigidbody = GetComponent<Rigidbody>();

		playerScale = transform.localScale;

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 movement = playerInput.Movement * speed * Time.deltaTime;
        Vector3 newPosition = transform.position + movement;
		
		MoveTo(newPosition);
    }

    public void MoveTo(Vector3 pos)
    {

        float xMin = -((boardDimension.width / 2) - (playerScale.x / 2));
        float xMax = -xMin;
        float zMin = -((boardDimension.length / 2) - (playerScale.z / 2));
        float zMax = -zMin;


        //TODO: Maybe tie stopping movement into triggers on game boarders.

        if (pos.x < xMin)
            pos.x = xMin;
        else if (pos.x > xMax)
            pos.x = xMax;

        if (pos.z < zMin)
            pos.z = zMin;
        else if (pos.z > zMax)
            pos.z = zMax;

        rigidbody.MovePosition(pos);
    }


}
