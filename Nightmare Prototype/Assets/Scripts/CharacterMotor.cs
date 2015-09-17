﻿using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour
{
	public Rigidbody rigidBody;
	
	public float acceleration = 0.01f;
	public float speed = 3f;

	public Vector3 velocityInput = Vector3.zero;
	public Vector3 realitiveVelocity = Vector3.zero;
	private Vector3 moveVelocity;
	
	public float jumpAmount = 4f;

	public bool grounded = false;
	public float slopeLimit = 60f;
	
	void Start ()
	{
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 moveInput = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));

		if (moveInput.magnitude > 1f)
		{
			moveInput.Normalize ();
		}

		velocityInput = Vector3.SmoothDamp (velocityInput, moveInput * speed, ref moveVelocity, acceleration);
		realitiveVelocity = Quaternion.FromToRotation (Vector3.forward, this.transform.forward) * velocityInput;
		
		rigidBody.velocity = new Vector3 (realitiveVelocity.x, rigidBody.velocity.y, realitiveVelocity.z);
		
		if (Input.GetButton ("Jump") && grounded)
		{
			rigidBody.AddForce (Vector3.up * jumpAmount, ForceMode.Impulse);
		}
	}
	
	void OnCollisionStay (Collision other)
	{
		foreach (ContactPoint c in other.contacts)
		{
			if (Mathf.Abs (Vector3.Angle (c.normal, Vector3.up)) < slopeLimit)
			{
				grounded = true;
			}
		}
	}
	
	void OnCollisionExit ()
	{
		grounded = false;
	}
}



