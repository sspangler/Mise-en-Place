using UnityEngine;
using System.Collections;

public class SnapTo : MonoBehaviour {

	public PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			if (playerController.pickedObject != null) {
				//playerController.pickedObject.GetComponent<Rigidbody> ().useGravity = true;
				//playerController.pickedObject.GetComponent<Rigidbody> ().isKinematic = false;
				playerController.pickedObject.GetComponent<Collider> ().enabled = true;
				playerController.pickedObject.transform.SetParent (transform);
				playerController.pickedObject.transform.position = transform.position;
				playerController.pickedObject.transform.rotation = transform.rotation;
				playerController.pickedObject = null;
			}
		}

	}
}