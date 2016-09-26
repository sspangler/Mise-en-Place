using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public OrgStage orgStage;
	public GameObject mainCamera;
	public PlayerController playerController;
	Rigidbody objectRigidbody;
	public Vector3 startPos;
	bool toolBar = false;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		objectRigidbody = GetComponent<Rigidbody> ();

		if (!toolBar) {
			Destroy(GameObject.Find ("Canvas/Grid"));
			Destroy(GameObject.Find ("Canvas/Panel"));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnMouseOver () {
		if (!toolBar) {
			if (Input.GetMouseButtonDown (0)) {
				PickUpItem ();
			}
		}
	}

	public void PickUpItem () {
		if (orgStage.isOrgStage) {
			if (playerController.pickedObject == null) {
				if (transform.parent != null && transform.parent.tag != "Player") {
					transform.parent.gameObject.GetComponent<SnapTo> ().itemCounter--; transform.parent.gameObject.GetComponent<BoxCollider> ().enabled = true; 
				}
				if (toolBar) {
					if (playerController.pickedObject != null) {
						playerController.pickedObject.transform.position = playerController.pickedObject.GetComponent<PickUp> ().startPos;
						playerController.DropObject ();
					}
					this.transform.SetParent (mainCamera.transform);
					transform.localPosition = new Vector3 (0, -.22f, 1);
					transform.localEulerAngles = new Vector3 (-95, 0, 0);
					playerController.pickedObject = this.gameObject;
					objectRigidbody.useGravity = false;
					objectRigidbody.isKinematic = true;
					GetComponent<Collider> ().enabled = false;
				} else {
					if (Vector3.Distance (mainCamera.transform.position, transform.position) < 4f) {
						this.transform.SetParent (mainCamera.transform);
						transform.localPosition = new Vector3 (0, -.22f, 1);
						transform.localEulerAngles = new Vector3 (-95, 0, 0);
						playerController.pickedObject = this.gameObject;
						objectRigidbody.useGravity = false;
						objectRigidbody.isKinematic = true;
						GetComponent<Collider> ().enabled = false;
					}
				}
			}
		} else { //not orgstage pick up ingredient not bin


		}
	}
}