//			Debug.Log ("test" + i);using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRandomBlock : MonoBehaviour {
	public GameObject random_block;
	public Transform empty;

	private List<Transform> lists;
	private List<Transform> replace_lists;


	void Start () {
		replace_lists = new List<Transform>();
		for (int i = 0; i < 8; i++) {
			replace_lists.Add(empty);
//			Debug.Log ("replace list initialize : " + i + replace_lists [i].name);
		}
	}

	void Update () {
	}

	List<Transform> ListUpdate (List<Transform> lists, GameObject obj) {
		for (int i = 0; i < lists.Count; i++) {
			if(lists[i].name == obj.name || lists[i].name == "ChildBlock") {
//				Debug.Log ("delete block : " + lists [i].name);
				lists.RemoveAt (i);
			}
		}
		return lists;
	}

	/* リストの順番を綺麗に直す関数
		[0]:(-1.0,1.0,-1.0)  | [4]:(-1.0,3.0,-1.0)
		[1]:(-1.0,1.0,1.0)   | [5]:(-1.0,3.0,1.0)
		[2]:(1.0,1.0,-1.0)   | [6]:(1.0,3.0,-1.0)
		[3]:(1.0,1.0,1.0)    | [7]:(1.0,3.0,1.0)
	*/
	List<Transform> ListReplace () {
		for (int i = 0; i < lists.Count; i++) {
			string[] str_lists = lists [i].name.Split ('(', ')');
//			Debug.Log (str_lists [1]);
			Debug.Log("lists count : " + lists.Count);
			switch (str_lists[1]) {
			case "-1.0, 1.0, -1.0":
				replace_lists [0] = lists [i];
//				Debug.Log ("replace lists 0 " + replace_lists [0].name);
				break;
			case "-1.0, 1.0, 1.0":
				replace_lists[1] = lists[i];
//				Debug.Log ("replace lists 1 " + replace_lists [1].name);
				break;
			case "1.0, 1.0, -1.0":
				replace_lists[2] = lists[i];
//				Debug.Log ("replace lists 2 " + replace_lists [2].name);
				break;
			case "1.0, 1.0, 1.0":
				replace_lists[3] = lists[i];
//				Debug.Log ("replace lists 3 " + replace_lists [3].name);
				break;
			case "-1.0, 3.0, -1.0":
				replace_lists[4] = lists[i];
//				Debug.Log ("replace lists 4 " + replace_lists [4].name);
				break;
			case "-1.0, 3.0, 1.0":
				replace_lists[5] = lists[i];
//				Debug.Log ("replace lists 5 " + replace_lists [5].name);
				break;
			case "1.0, 3.0, -1.0":
				replace_lists[6] = lists[i];
//				Debug.Log ("replace lists 6 " + replace_lists [6].name);
				break;
			case "1.0, 3.0, 1.0":
				replace_lists[7] = lists[i];
//				Debug.Log ("replace lists 7 " + replace_lists [7].name);
				break;
			default:
				Debug.Log ("block hidden " + lists [i].name);
				GameObject block = GameObject.Find ("/Scene root/Marker scene hiro/RandomBlock/" + lists [i].name);
				block.GetComponent<BoxCollider> ().enabled = false;
				block.GetComponent<MeshRenderer> ().enabled = false;
				lists.RemoveAt (i);
//				Debug.Log(block.name);
//				GameObject.Find ("/Scene root/Marker scene hiro/RandomBlock/" + lists [i].name).SetActive (false);
//				Destroy (GameObject.Find ("/Scene root/Marker scene hiro/RandomBlock/" + lists [i].name));
				break;
			}
		}
		return replace_lists;
	}

	public void ListCreate () {
		lists = new List<Transform> (random_block.GetComponentsInChildren<Transform>());
		lists = ListUpdate (lists, random_block);
//		Debug.Log ("random block count : " + lists.Count);
//		foreach (Transform child in lists) {
//			Debug.Log ("random block name : " + child.name);
//		}
	}

	public List<Transform> GetLists() {
		return ListReplace ();
	}

}