using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightDirectionVelocity : MonoBehaviour
{

	public float speed = 10;
	private Rigidbody2D rb;

	void Start ()
	{

		rb = GetComponent<Rigidbody2D> ();

		//The degree to which this object is affected by gravity.
		rb.gravityScale = 0;

		//The rigidBody inertia.
		rb.linearDamping = 10;

		//Mass of the rigidbody.
		rb.mass = 10;

	}


	//update is called every frame at fixed intervals
	void FixedUpdate ()
	{

		//in Unity change the Rigidbody2d interpolation to "interpolate"
		Vector2 vel = rb.linearVelocity;

		//Input.GetKey returns true is the key is held down
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		vel.x = speed;

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		vel.x = -speed;

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		vel.y = speed;

		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		vel.y = -speed;

		rb.linearVelocity = vel;
	}
}