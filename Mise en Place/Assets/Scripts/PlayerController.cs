using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// Movement-----------------------
		if (Input.GetKey (KeyCode.W)) 
			MoveForward ();
		if (Input.GetKey (KeyCode.S)) 
			MoveBackwards ();
		if (Input.GetKey (KeyCode.A)) 
			MoveLeft ();
		if (Input.GetKey (KeyCode.D)) 
			MoveRight ();
		//---------------------------------
	}

	void MoveForward () {
		transform.Translate (transform.forward * moveSpeed * Time.deltaTime);
	}

	void MoveBackwards() {
		transform.Translate (-transform.forward * moveSpeed * Time.deltaTime);
	}

	void MoveLeft () {
		transform.Translate (-transform.right * moveSpeed * Time.deltaTime);
	}

	void MoveRight () {
		transform.Translate (transform.right * moveSpeed * Time.deltaTime);
	}
}