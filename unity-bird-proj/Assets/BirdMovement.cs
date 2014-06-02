using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 flapVelocity;
	public float maxSpeed = 5f;
	public float forwardSpeed = 1f;

	bool didFlap = false;

	// Use this for initialization
	void Start () {
	
	}

	//do graphic and input updates here
	void Update(){
		//check for space bar input or left mouse click (on touch responds to GetMouseButtonDown(0) as well
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
			didFlap = true;
		}
	}
	
	// do physics engine updates here
	void FixedUpdate () {
		velocity.x = forwardSpeed;
		velocity += gravity * Time.deltaTime;

		//before we flap
		if (didFlap == true) {
			didFlap = false;
			if(velocity.y <0)
				velocity.y = 0;
			velocity += flapVelocity;
		}

		velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

		transform.position += velocity * Time.deltaTime;

		//for handling the rotation of the bird when it is losing speed
		float angle = 0;
		if(velocity.y < 0)
		{
			angle = Mathf.Lerp(0, -90, -velocity.y/maxSpeed);
		}

		transform.rotation = Quaternion.Euler (0, 0, angle);
	}
}
