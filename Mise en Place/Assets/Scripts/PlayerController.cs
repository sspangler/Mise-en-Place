using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody playerRigidbody;
	public float moveSpeed;

	LayerMask layerMask;
//	public bool inFront;
//	public bool inBack;
//	public bool toLeft;
//	public bool toRight;

	// Use this for initialization
	void Start () {
		layerMask = 1 << LayerMask.NameToLayer ("Enviorment");
	}

	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position + Vector3.down/1.5f, transform.forward, Color.blue);

		Debug.DrawRay (transform.position + Vector3.up/1.5f, transform.forward, Color.blue);
		// Movement-----------------------
		if (Input.GetKey (KeyCode.W)) {
			if (!Physics.Raycast (transform.position + Vector3.up/ 1f, transform.forward, .51f, layerMask) &&
			    !Physics.Raycast (transform.position + Vector3.down/ 1f, transform.forward, .51f, layerMask)) {
				MoveForward ();
			}
		}
		if (Input.GetKey (KeyCode.S)) 
			MoveBackwards ();
		if (Input.GetKey (KeyCode.A)) 
			MoveLeft ();
		if (Input.GetKey (KeyCode.D)) 
			MoveRight ();

		transform.position = new Vector3 (transform.position.x, 1, transform.position.z);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		//---------------------------------


	}

	void MoveForward () {
		//transform.Translate (transform.forward * moveSpeed * Time.deltaTime);
		transform.position += (transform.forward * moveSpeed * Time.deltaTime);
	}

	void MoveBackwards() {
		//transform.Translate (-transform.forward * moveSpeed * Time.deltaTime);
		transform.position += (-transform.forward * moveSpeed * Time.deltaTime);
	}

	void MoveLeft () {
		//transform.Translate (-transform.right * moveSpeed * Time.deltaTime);
		transform.position += (-transform.right * moveSpeed * Time.deltaTime);
	}

	void MoveRight () {
		//transform.Translate (transform.right * moveSpeed * Time.deltaTime);
		transform.position += (transform.right * moveSpeed * Time.deltaTime);
	}

	void OnCollisionStay (Collision col) {
		if (col.transform.tag == "Enviorment") {
			playerRigidbody.velocity = Vector3.zero;
		}
	}

}