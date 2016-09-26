using UnityEngine;
using System.Collections;

public class ObjectOutline : MonoBehaviour {
	Color startcolor;
	Color transparent;

	// Use this for initialization
	void Start () {
		startcolor = GetComponent<MeshRenderer> ().material.color;
		transparent = GetComponent<MeshRenderer> ().material.color;
		transparent = new Vector4 (startcolor.r, startcolor.b, startcolor.g, 0);
		GetComponent<MeshRenderer> ().material.SetColor ("_OutlineColor", transparent);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver () {
		if (Vector3.Distance(transform.position, Camera.main.transform.position) < 4)
			GetComponent<MeshRenderer> ().material.SetColor ("_OutlineColor", Color.yellow);
	}

	void OnMouseExit() {
		GetComponent<MeshRenderer> ().material.SetColor ("_OutlineColor", transparent);

	}
}
