//			Debug.Log ("test" + i);using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRandomBlock : MonoBehaviour {
	public GameObject random_block;

	private List<Transform> lists;

	void Start () {
	}

	void Update () {
		lists = new List<Transform> (random_block.GetComponentsInChildren<Transform>());
		lists = ListUpdate (lists, random_block);
		Debug.Log (lists.Count);
		foreach (Transform child in lists) {
			Debug.Log (child.name);
		}
	}

	List<Transform> ListUpdate (List<Transform> lists, GameObject obj) {
		for (int i = 0; i < lists.Count; i++) {
			if(lists[i].name == obj.name) {
				lists.RemoveAt (i);
			}
		}
		return lists;
	}
}