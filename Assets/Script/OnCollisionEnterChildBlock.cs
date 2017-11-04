using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterChildBlock : MonoBehaviour {
	private GameObject _parent;

	void Start () {
		_parent = transform.parent.gameObject;
		Debug.Log (_parent.name);
	}

	void Update () {
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject != _parent) {
			Debug.Log ("on collision!!!");
			_parent.GetComponent<GoDown>().enabled = false;
			_parent.GetComponent<PositionControlWithWatson>().enabled = false;

			Vector3 position = _parent.transform.position;
			Debug.Log ("Random position : " + _parent.transform.position);
			position.x = Mathf.RoundToInt (_parent.transform.position.x);
			position.y = Mathf.RoundToInt (_parent.transform.position.y);
			position.z = Mathf.RoundToInt (_parent.transform.position.z);
			_parent.transform.position = position;
			Debug.Log ("Random position update : " + _parent.transform.position);
			_parent.name = "Vector3" + _parent.transform.position + " - " + _parent.GetComponent<Renderer>().material.color;

			Destroy (_parent.GetComponent ("Rigidbody"));
			Destroy (this.GetComponent ("Rigidbody"));
			Destroy (this.gameObject);
		}
	}
}