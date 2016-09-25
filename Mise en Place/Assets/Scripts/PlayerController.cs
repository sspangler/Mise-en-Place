using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody playerRigidbody;
	public float moveSpeed;
	public GameObject pickedObject;

	LayerMask layerMask;

	// Use this for initialization
	void Start () {
		layerMask = 1 << LayerMask.NameToLayer ("Enviorment");
	}

	// Update is called once per frame
	void Update () {
		// Movement-----------------------
		if (Input.GetKey (KeyCode.W)) {
			if (!Physics.Raycast (transform.position + Vector3.up/ 1f, transform.forward, .51f, layerMask) &&
			    !Physics.Raycast (transform.position + Vector3.down/ 1f, transform.forward, .51f, layerMask)) {
				MoveForward ();
			}
		}
		if (Input.GetKey (KeyCode.S)) {
			if (!Physics.Raycast (transform.position + Vector3.up / 1f, -transform.forward, .51f, layerMask) &&
			    !Physics.Raycast (transform.position + Vector3.down / 1f, -transform.forward, .51f, layerMask)) {
				MoveBackwards ();
			}
		}
		if (Input.GetKey (KeyCode.A)) {
			if (!Physics.Raycast (transform.position + Vector3.up / 1f, -transform.right, .51f, layerMask) &&
				!Physics.Raycast (transform.position + Vector3.down / 1f, -transform.right, .51f, layerMask)) {
				MoveLeft ();
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			if (!Physics.Raycast (transform.position + Vector3.up / 1f, transform.right, .51f, layerMask) &&
				!Physics.Raycast (transform.position + Vector3.down / 1f, transform.right, .51f, layerMask)) {
				MoveRight ();
			}
		}

		transform.position = new Vector3 (transform.position.x, 1, transform.position.z);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		//---------------------------------

		if (Input.GetMouseButtonDown (1) && pickedObject != null) {
			DropObject ();
		}
	}

	void MoveForward () {
		transform.position += (transform.forward * moveSpeed * Time.deltaTime);
	}

	void MoveBackwards() {
		transform.position += (-transform.forward * moveSpeed * Time.deltaTime);
	}

	void MoveLeft () {
		transform.position += (-transform.right * moveSpeed * Time.deltaTime);
	}

	void MoveRight () {
		transform.position += (transform.right * moveSpeed * Time.deltaTime);
	}
		

	public void DropObject () {
		pickedObject.GetComponent<Rigidbody> ().useGravity = true;
		pickedObject.GetComponent<Rigidbody> ().isKinematic = false;
		pickedObject.GetComponent<Collider> ().enabled = true;
		pickedObject.transform.SetParent (null);
		pickedObject = null;
	}
}