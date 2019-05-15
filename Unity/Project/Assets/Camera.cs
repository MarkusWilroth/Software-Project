using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public float panSpeed = 7f;
	public float panBorderThickness = 5f;
	public Vector2 panLimit;

	public float scrollSpeed = 2f;
	public float minY = 20f;
	public float maxY = 120f;
	
	// Update is called once per frame
	void Update () {

        //|| Input.mousePosition.y >= Screen.height - panBorderThickness


        Vector3 pos = transform.position;
		if (Input.GetKey ("w") ) {
			pos.y += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey ("s")) {
			pos.y -= panSpeed * Time.deltaTime;
		}
		if (Input.GetKey ("d")) {
			pos.x += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey ("a")) {
			pos.x -= panSpeed * Time.deltaTime;
		}

		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		pos.z += scroll * scrollSpeed * 50f * Time.deltaTime;

		pos.x = Mathf.Clamp (pos.x, -panLimit.x, panLimit.x);
		pos.z = Mathf.Clamp (pos.z, minY, maxY);
		pos.y = Mathf.Clamp (pos.y, -panLimit.y, panLimit.y);

		transform.position = pos;
	}
}
