using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;

	public Vector3 offset; // stores how far away the player should be from the camera

	public bool useOffsetValues;

	public float rotateSpeed; // how fast our camera rotates as we move our player

	public Transform pivot;

	public float maxViewAngle;
	public float minViewAngle;

	public bool invertY;

	// Use this for initialization
	void Start () {
		if(!useOffsetValues) {
			offset = target.position - transform.position;
		}

		 // move the pivot to wherever the current player is
		pivot.transform.position = target.transform.position;
		// make the pivot the child of the player
		// pivot.transform.parent = target.transform;
		pivot.transform.parent = null;

		// Removes the cursor when moving the camera angle
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// LateUpdate is once every fixed amount of frames (Makes the player move smoothly instead of moving in a glitchy manner)
	void LateUpdate () {

		pivot.transform.position = target.transform.position;

		// Get the X position of the mouse & rotate the target
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		// target.Rotate(0, horizontal, 0);
		pivot.Rotate(0, horizontal, 0);

		// Get the Y position of the mouse & rotate the pivot
		float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
		// pivot.Rotate(-vertical, 0, 0);
		if(invertY) {
			pivot.Rotate(vertical, 0, 0);
		} else {
			pivot.Rotate(-vertical, 0, 0);
		}

		// Limit up/down camera rotation
		if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f) {
			pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
		}

		if(pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360 + minViewAngle) {
			pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
		}

		// Move the camera based on the current rotation of the target & the original offset
		// float desiredYAngle = target.eulerAngles.y;
		float desiredYAngle = pivot.eulerAngles.y;
		float desiredXAngle = pivot.eulerAngles.x;
		Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
		transform.position = target.position - (rotation * offset);
		
		// transform.position = target.position - offset;

		if(transform.position.y < target.position.y) {
			transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
		}

		transform.LookAt(target);
	}
}
