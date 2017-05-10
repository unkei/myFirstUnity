using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script1 : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Collider2D[] carr = Physics2D.OverlapPointAll (pos);
			if (carr.Length > 0) {
				foreach (Collider2D c in carr) {
					c.GetComponent<Renderer> ().enabled = false;
				}
			}
		}
	}
}
