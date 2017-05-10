using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script1 : MonoBehaviour {
//	public float low = -5f;
//	public float high = 5f;
//	float dx = 0.01f;

	public float max = 2.0f;
	public float min = 0.5f;
	float d = 0.01f;
	static float x = 0f;
	static float y = 0f;

	// Use this for initialization
	void Start () {
//		dx = Time.deltaTime * 1f;

		d = 1.0f * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
//		Vector2 v = transform.position;
//		v.x += 0.01f;
//		transform.position = v;

//		transform.Translate(-0.01f, 0, 0);

//		Vector2 v = transform.position;
//		v.x += dx;
//		if (v.x > high) {
//			v.x = high;
//			dx *= -1;
//		}
//		if (v.x < low) {
//			v.x = low;
//			dx *= -1;
//		}
//		transform.position = v;

//		transform.Rotate (0, 0, Time.deltaTime * 100f);

//		Vector2 s = transform.localScale;
//		s.x += d;
//		s.y += d;
//		if (s.x > max) {
//			s.x = max;
//			s.y = max;
//			d *= -1;
//		}
//		if (s.x < min) {
//			s.x = min;
//			s.y = min;
//			d *= -1;
//		}
//		transform.localScale = s;

//		if (Input.GetKey (KeyCode.RightArrow)) {
//			transform.Translate (d, 0, 0);
//		}
//		if (Input.GetKey (KeyCode.LeftArrow)) {
//			transform.Translate (d * -1, 0, 0);
//		}
//		if (Input.GetKey (KeyCode.UpArrow)) {
//			transform.Translate (0, d, 0);
//		}
//		if (Input.GetKey (KeyCode.DownArrow)) {
//			transform.Translate (0, d * -1, 0);
//		}

//		float x = Input.GetAxis ("Horizontal");
//		float y = Input.GetAxis ("Vertical");
//		transform.Translate (x * d, y * d, 0);

//		if (Input.GetMouseButton (0)) {
//			Vector2 v = Input.mousePosition;
//			float x = 0f;
//			float y = 0f;
//			float right = Screen.width / 3 * 2;
//			float left = Screen.width / 3;
//			float down = Screen.height / 3 * 2;
//			float up = Screen.height / 3;
//			if (left > v.x) {
//				x = -1f * d;
//			}
//			if (right < v.x) {
//				x = 1f * d;
//			}
//			if (up > v.y) {
//				y = -1f * d;
//			}
//			if (down < v.y) {
//				y = 1f * d;
//			}
//			transform.Translate (x, y, 0);
//		}

		float right = Screen.width / 3 * 2;
		float left = Screen.width / 3;
		float down = Screen.height / 3 * 2;
		float up = Screen.height / 3;
		foreach(Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) {
				Vector2 v = touch.position;
				if (left > v.x) {
					x = -1f * d;
				}
				if (right < v.x) {
					x = 1f * d;
				}
				if (up > v.y) {
					y = -1f * d;
				}
				if (down < v.y) {
					y = 1f * d;
				}
//				return;
			}
			if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
				x = 0f;
				y = 0f;
			}
		}
		transform.Translate (x, y, 0);
	}
}
