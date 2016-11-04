using UnityEngine;
using System.Collections;

public class proteins : MonoBehaviour {

	public bool cooking;
	public float timeToCook;
	public float cookedTime;
	public float burntTime;

	public Color startColor;
	public Color cookedColor;
	public Color burntColor = Color.black;

	MeshRenderer foodColor;

	public bool needSpatula;
	// Use this for initialization
	void Start () {
		foodColor = GetComponent<MeshRenderer> ();
		startColor = foodColor.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (cooking) {
			cookedTime += Time.deltaTime;
			foodColor.material.color = Color.Lerp (startColor, burntColor, cookedTime / burntTime); //lerps between the starting color and black
		}

		if (cookedTime > 0) {
			GetComponent<PickUpFood>().needSpatula = true;
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.name == "Oven") {
			cooking = true;
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.name == "Oven") {
			cooking = false;
		}
	}
}
