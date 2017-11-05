using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckBlock : MonoBehaviour {
	public GameObject check_random_block;
	public GameObject check_guidline_block;

	private List<Transform> random_block_lists_get;
	private List<Transform> guidline_block_lists_get;

	void Start () {
	}
	
	void Update () {
	}

	public void CheckLists () {
		CheckRandomBlock random_block_lists = check_random_block.GetComponent<CheckRandomBlock> ();
		CheckGuidlineBlock guidline_block_lists = check_guidline_block.GetComponent<CheckGuidlineBlock> ();
		random_block_lists_get = random_block_lists.GetLists ();
		guidline_block_lists_get = guidline_block_lists.GetLists ();
//		Debug.Log("random block count : " + random_block_lists_get.Count + " / guidline block count : " + guidline_block_lists_get.Count);

		for(int i = 0; i < random_block_lists_get.Count; i++) {
			Debug.Log("RandomBlock:" + random_block_lists_get[i].name + " / GuidlineBlock:" + guidline_block_lists_get[i].name);
		}

		int count = 0;
		for(int i = 0; i < random_block_lists_get.Count; i++) {
			if (random_block_lists_get [i].name == guidline_block_lists_get [i].name) {
				count += 1;
			}
		}
		if (count == 8) {
			Debug.Log ("change scene!!!");
			SceneManager.LoadScene ("ClearScene");
		}

	}
}
