using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterChildBlock : MonoBehaviour {
	private GameObject _parent;

	void Start () {
		_parent = transform.parent.gameObject;
		Debug.Log ("start!!!");
		Debug.Log (_parent.name);
	}

	void Update () {
	}

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("on collision!!!");
		if (collision.gameObject != _parent) {
			Debug.Log ("if program into!!!");
			_parent.GetComponent<GoDown>().enabled = false;
			_parent.GetComponent<PositionControlWithWatson>().enabled = false;
			Destroy (_parent.GetComponent("Rigidbody"));
			Destroy (GetComponent("Rigidbody"));
		}
	}
}