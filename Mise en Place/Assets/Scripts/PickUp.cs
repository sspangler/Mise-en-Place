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
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (Camera.main.transform.position, (Input.mousePosition), Color.green);
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
				if (toolBar) {
					if (playerController.pickedObject != null) {
						playerController.pickedObject.transform.position = playerController.pickedObject.GetComponent<PickUp> ().startPos;
						playerController.DropObject ();
					}
					this.transform.SetParent (mainCamera.transform);
					transform.localPosition = new Vector3 (0, .05f, 1);
					transform.localEulerAngles = new Vector3 (0, 90, -15f);
					playerController.pickedObject = this.gameObject;
					objectRigidbody.useGravity = false;
					objectRigidbody.isKinematic = true;
					GetComponent<Collider> ().enabled = false;
				} else {
					if (Vector3.Distance (mainCamera.transform.position, transform.position) < 2f) {
						this.transform.SetParent (mainCamera.transform);
						transform.localPosition = new Vector3 (0, .05f, 1);
						transform.localEulerAngles = new Vector3 (0, 90, -15f);
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