using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomBlock : MonoBehaviour {
	public GameObject prefab;
	public Material red;
	public Material green;
	public Material blue;
	public Material yellow;

	private Vector3 vector_3;
	private GameObject block;

	void Start () {
		vector_3 = new Vector3 (ReturnRandomValue(-1, 1), 9, ReturnRandomValue(-1, 1));
		block = Instantiate (prefab, vector_3, Quaternion.identity) as GameObject;
		block.transform.parent = this.transform;
		SetColor (block);
	}

	void Update () {
		if (block.GetComponent<GoDown>().enabled == false) {
			vector_3 = new Vector3 (ReturnRandomValue(-1, 1), 9, ReturnRandomValue(-1, 1));
			block = Instantiate (prefab, vector_3, Quaternion.identity) as GameObject;
			block.transform.parent = this.transform;
			SetColor (block);
		}
	}

	// 座標を奇数にする処理
	int ReturnRandomValue (int min, int max) {
		int val = Random.Range (min, max);
		if (val % 2 == 0) {
			if (Random.Range (0, 1) == 0) {
				val += 1;
			} else {
				val -= 1;
			}
		}
		return val;
	}

	void SetColor (GameObject block) {
		int i = Random.Range (0, 4);
		switch(i) {
			case 0:
				block.GetComponent<Renderer> ().material = red;
				break;

			case 1:
				block.GetComponent<Renderer> ().material = green;
				break;

			case 2:
				block.GetComponent<Renderer> ().material = blue;
				break;

			case 3:
				block.GetComponent<Renderer> ().material = yellow;
				break;
		}
	}
}