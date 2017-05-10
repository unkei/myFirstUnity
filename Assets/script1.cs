using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script1 : MonoBehaviour {

	float d = 1f;

	void Start () {
		d = 2.0f * Time.deltaTime;
	}

	void Update () {
//		float x = Input.GetAxis ("Horizontal");
//		float y = Input.GetAxis ("Vertical");
//		GetComponent<Rigidbody2D>().AddForce(new Vector2(x * d * 250, 0));kk
	}

	void FixedUpdate () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		GetComponent<Rigidbody2D>().AddForce(new Vector2(x * d * 250, 0));
	}

//	void OnCollisionEnter2D(Collision2D collision) {
//		collision.gameObject.GetComponent<Renderer> ().enabled = false;
//		collision.collider.enabled = false;
//	}

	void OnTriggerEnter2D(Collider2D collider) {
		collider.gameObject.GetComponent<Renderer> ().material.color = new Color(1f, 1f, 1f, 0.5f);
	}

	void OnTriggerExit2D(Collider2D collider) {
		collider.gameObject.GetComponent<Renderer> ().material.color = new Color(1f, 1f, 1f, 1f);
	}
}
