using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject mainCamera;
	public float XSensitivity = 2f;
	public float YSensitivity = 2f;
	public bool clampVerticalRotation = true;
	public float MinimumX = -90F;
	public float MaximumX = 90F;

	public bool lockCursor = true;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {

		float yRot = Input.GetAxis("Mouse Y") * YSensitivity;
		float xRot = Input.GetAxis("Mouse X") * XSensitivity;

		if (lockCursor == true) {
			transform.Rotate( new Vector3 (0,xRot,0));
			mainCamera.transform.Rotate (new Vector3 (-yRot, 0, 0));
			mainCamera.transform.eulerAngles = new Vector3 (mainCamera.transform.eulerAngles.x, transform.eulerAngles.y, 0);
		}

		if(Input.GetKeyDown(KeyCode.LeftControl) && lockCursor == true)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			lockCursor = false;
		}
		else if(Input.GetMouseButtonUp(0) && lockCursor == false)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			lockCursor = true;
		}
	}
}