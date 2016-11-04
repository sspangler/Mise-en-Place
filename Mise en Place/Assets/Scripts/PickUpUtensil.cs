using UnityEngine;
using System.Collections;

public class PickUpUtensil : MonoBehaviour {
	public OrgStage orgStage;
	public GameObject mainCamera;
	public PlayerController playerController;
	Rigidbody objectRigidbody;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		objectRigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			PickUpItem ();
		}
	}

	public void PickUpItem () {
		if (playerController.pickedUtensil == null) {
			if (transform.parent != null && transform.parent.tag != "Player") {
				transform.parent.gameObject.GetComponent<SnapTo> ().itemCounter--;
				transform.parent.gameObject.GetComponent<BoxCollider> ().enabled = true; 
			}
			if (Vector3.Distance (mainCamera.transform.position, transform.position) < 4f) {
				this.transform.SetParent (mainCamera.transform);
				//transform.localPosition = new Vector3 (0, -.22f, 1);
				//transform.localEulerAngles = new Vector3 (-95, 0, 0);
				playerController.pickedUtensil = this.gameObject;
				objectRigidbody.useGravity = false;
				objectRigidbody.isKinematic = true;
				GetComponent<Collider> ().enabled = false;
			}
		}
	}
}
