using UnityEngine;
using System.Collections;

public class SnapTo : MonoBehaviour {

	public PlayerController playerController;
	public bool isFull;
	public int itemCounter;
	public int maxItems;
	// Use this for initialization
	void Start () {
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) {
			if (itemCounter + 1 <= maxItems) {
				if (playerController.pickedFood != null) {
					playerController.pickedFood.GetComponent<Collider> ().enabled = true;
					playerController.pickedFood.transform.SetParent (transform);
					playerController.pickedFood.transform.position = transform.position + Vector3.up/ 6.0f;
					playerController.pickedFood = null;
					itemCounter++;
					if (itemCounter == maxItems) {
						GetComponent<Collider> ().enabled = false;
					}
				}
			}
		}

	}
}