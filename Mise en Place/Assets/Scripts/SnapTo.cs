﻿using UnityEngine;
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
				if (playerController.pickedObject != null) {
					//playerController.pickedObject.GetComponent<Rigidbody> ().useGravity = true;
					//playerController.pickedObject.GetComponent<Rigidbody> ().isKinematic = false;
					playerController.pickedObject.GetComponent<Collider> ().enabled = true;
					playerController.pickedObject.transform.SetParent (transform);
					playerController.pickedObject.transform.position = transform.position + Vector3.up/ 6.0f;
					//playerController.pickedObject.transform.eulerAngles = new Vector3 (90, 0, 90);;
					playerController.pickedObject = null;
					itemCounter++;
					if (itemCounter == maxItems) {
						GetComponent<Collider> ().enabled = false;
					}
				}
			}
		}

	}
}