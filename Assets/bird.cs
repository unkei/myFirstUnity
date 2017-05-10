using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour {

	float d = 1f;
	bool clickflag = false;

	void Start () {
		d = 100.0f * Time.deltaTime;		
	}
	
	void Update () {
		float dx = Input.mousePosition.x;
		float dy = Input.mousePosition.y;
		if (dx > 200) {
			dx = 200f;
		}
		if (dy > 200) {
			dy = 200f;
		}
		if (!clickflag) {
			if (Input.GetMouseButtonDown (0)) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (d * dx, d * dy));
			}
		}
	}
}
