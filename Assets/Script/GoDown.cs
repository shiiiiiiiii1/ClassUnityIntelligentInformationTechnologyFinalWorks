using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour {

	private Vector3 position;
	private float time;

	void Start () {
		time = 0;
	}

	void Update () {
		time += Time.deltaTime;
		if (time > 2) {
			position = transform.position;
			transform.position = new Vector3 (position.x, position.y - 2, position.z);
			time = 0;
		}
	}
}