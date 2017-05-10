using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	float press = 0;

	void Start () {
		
	}
	
	void Update () {
		if (!bird.gameflag) {
			return;
		}
		if (press > 50f) {
			bird.score += 100;
			GameObject.Destroy (gameObject);
		}
	}

	void OnCollisionStay2D(Collision2D collision) {
		if (!bird.gameflag) {
			return;
		}
		if (collision.gameObject.tag == "block") {
			Vector2 v = collision.rigidbody.velocity - GetComponent<Rigidbody2D> ().velocity;
			float p = Mathf.Sqrt (v.x * v.x + v.y * v.y);
			Behaviour halo = GetComponent ("Halo") as Behaviour;
			if (p > 0.1f) {
				halo.enabled = true;
			} else {
				halo.enabled = false;
			}
			press += p * p;
			bird.score += p;
		}
	}
}
