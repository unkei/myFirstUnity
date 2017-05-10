using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour {

	float d = 1f;

	void Start () {
		d = 1.0f * Time.deltaTime;	
	}
	
	void Update () {
		if (ball.endflag) {
			return;
		}
		float x = Input.GetAxis ("Horizontal");
		transform.Translate (new Vector2 (x * d * 5f, 0));
	}
}
