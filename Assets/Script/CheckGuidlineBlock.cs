//			Debug.Log ("test" + i);using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGuidlineBlock : MonoBehaviour {
	public GameObject guidline_group;

	void Start () {
	}

	void Update () {
		List<Transform> lists = new List<Transform> (guidline_group.GetComponentsInChildren<Transform>());
		lists = ListUpdate (lists, guidline_group);
		Debug.Log ("Guidline block count : " + lists.Count);
		foreach (Transform child in lists) {
			Debug.Log ("block name : " + child.name);
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