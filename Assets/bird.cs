using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bird : MonoBehaviour {

	float d = 1f;
	Vector2 defaultPos;
	bool clickflag = false;
	bool checkflag = false;

	static int birds = 3;

	public static bool gameflag = true;
	public static float score = 0f;

	public Text scoreText;
	public Text countText;
	public Text msgText;

	void Start () {
		scoreText.text = "Score: 0";
		countText.text = "Birds: 0";
		msgText.text = "";
		d = 100.0f * Time.deltaTime;		
		defaultPos = new Vector2 (transform.position.x, transform.position.y);
	}
	
	void Update () {
		if (!bird.gameflag) {
			return;
		}
		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;
		Vector2 v = Camera.main.WorldToScreenPoint (transform.position);
		float dx = x - v.x;
		float dy = y - v.y;
		if (dx > 200) {
			dx = 200f;
		}
		if (dy > 200) {
			dy = 200f;
		}
		if (!clickflag) {
			if (Input.GetMouseButtonDown (0)) {
				bird.birds--;
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (d * dx, d * dy));
				clickflag = true;
			}
		} else {
			if (Input.GetMouseButtonUp (0)) {
				checkflag = true;
			}
		}
		showScore ();
	}

	void FixedUpdate() {
		if (checkflag) {
			enemyCheck ();
			birdCheck ();
		}
	}

	void showScore() {
		scoreText.text = "Score: " + (int)bird.score;
		countText.text = "Birds: " + bird.birds;
	}

	void enemyCheck() {
		GameObject[] crates = GameObject.FindGameObjectsWithTag ("enemy");
		if (crates.Length == 0) {
			bird.gameflag = false;
			bird.score += bird.birds * 100;
			msgText.text = "CLEAR!!";
		}
	}

	void birdCheck() {
		Vector2 v = GetComponent<Rigidbody2D> ().velocity;
		if (v.x * v.x + v.y * v.y == 0) {
			if (birds > 0) {
				transform.position = defaultPos;
				Quaternion q = transform.rotation;
				q.z = 0f;
				transform.rotation = q;
				clickflag = false;
				checkflag = false;
			} else {
				bird.gameflag = false;
				msgText.text = "GAME OVER.";
			}
		}
	}
}
