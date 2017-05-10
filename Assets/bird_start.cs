using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bird_start : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
//			Application.LoadLevel ("bird");
			SceneManager.LoadScene ("bird");
		}
	}
}
