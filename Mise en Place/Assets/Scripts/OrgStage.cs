using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrgStage : MonoBehaviour {

	public bool isOrgStage = true;
	public float timer;
	public Text timeText;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 
		if (timer > 0) {
			timer -= Time.deltaTime;
			timeText.text = "Time Left: " + (int)timer;
		}
		if (timer <= 0 && isOrgStage) {
			isOrgStage = false;
			StageEnd ();
		}

	}


	void StageEnd () {
		foreach ( GameObject item in GameObject.FindGameObjectsWithTag("OrgStage")) {
//			Destroy(item);
		}
	}
}