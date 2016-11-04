using UnityEngine;
using System.Collections;

public class PickUpFood : MonoBehaviour {

	public OrgStage orgStage;
	public GameObject mainCamera;
	public PlayerController playerController;
	Rigidbody objectRigidbody;


	public bool needSpatula;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		objectRigidbody = GetComponent<Rigidbody> ();
	}
		
	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			PickUpItem ();
		}
	}

	public void PickUpItem () {
		if (orgStage.isOrgStage) {
			if (playerController.pickedFood == null) {
				if (transform.parent != null && transform.parent.tag != "Player") { //this is for removing items from the bins
					transform.parent.gameObject.GetComponent<SnapTo> ().itemCounter--; 
					transform.parent.gameObject.GetComponent<BoxCollider> ().enabled = true; 
				}
					
				if (!needSpatula || (needSpatula && playerController.pickedUtensil.name == "Spatula")) { //if you dont need spatula or need the spatula and have it
					if (Vector3.Distance (mainCamera.transform.position, transform.position) < 4f) { //this is just for picking them up and centering them
						this.transform.SetParent (mainCamera.transform);
						//transform.localPosition = new Vector3 (0, -.22f, 1);
						//transform.localEulerAngles = new Vector3 (-95, 0, 0);
						playerController.pickedFood = this.gameObject;
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