using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public float panSpeed = 7f;
	public float panBorderThickness = 5f;

	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
			pos.y += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey ("s") || Input.mousePosition.y <= panBorderThickness) {
			pos.y -= panSpeed * Time.deltaTime;
		}
		if (Input.GetKey ("d") || Input.mousePosition.x >= Screen.height - panBorderThickness) {
			pos.x += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey ("a") || Input.mousePosition.x <= panBorderThickness) {
			pos.x -= panSpeed * Time.deltaTime;
		}

		transform.position = pos;
	}
}
