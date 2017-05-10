using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour {

	float d = 1f;
	float dx = 0.1f;
	float dy = 0.1f;
	int counter = 0;

	public Text msg;
	public static bool endflag = false;

	void Start () {
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (d * dx, d * dy));
		d = 50.0f * Time.deltaTime;
		msg.text = "";
	}

	void FixedUpdate() {
		if (ball.endflag) {
			return;
		}
		counter++;
		if (counter == 1000) {
			counter = 0;
			Vector2 v = GetComponent<Rigidbody2D> ().velocity;
			v.x /= 100f;
			v.y /= 100f;
			GetComponent<Rigidbody2D> ().AddForce (v);
		}
	}

	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (ball.endflag) {
			return;
		}
		if (collision.gameObject.tag == "endwall") {
			endflag = true;
			msg.text = "GAMEOVER";
		}
		if (collision.gameObject.tag == "block") {
			collision.gameObject.GetComponent<Renderer> ().enabled = false;
			collision.gameObject.GetComponent<Collider2D> ().enabled = false;
			if (isClear ()) {
				ball.endflag = true;
				msg.text = "CLEAR!!";
			}
		}
		Vector2 v = GetComponent<Rigidbody2D> ().velocity;
		float rnd = Random.value;
		if (Mathf.Abs (v.x) < 1f) {
			v.x *= 2f;
		}
		if (Mathf.Abs (v.y) < 1f) {
			v.y *= 2f;
		}
		GetComponent<Rigidbody2D> ().velocity = v;
	}

	bool isClear() {
		bool f = true;
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("block");
		foreach(GameObject obj in objs) {
			if (obj.GetComponent<Renderer>().enabled) {
				f = false;
				break;
			}
		}
		return f;
	}
}
