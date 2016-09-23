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

	void OnMouseEnter () {
		GetComponent<MeshRenderer> ().material.SetColor ("_OutlineColor", Color.yellow);
	}

	void OnMouseExit() {
		GetComponent<MeshRenderer> ().material.SetColor ("_OutlineColor", transparent);

	}
}
