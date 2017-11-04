using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGuidlineBlock : MonoBehaviour {
	public GameObject prefab;
	public Material red;
	public Material green;
	public Material blue;
	public Material yellow;

	void Start () {
		for (int y = 1; y < 5; y += 2) {
			for (int x = -1; x < 3; x += 2) {
				for (int z = -1; z < 3; z += 2) {
					GameObject block = Instantiate (prefab, new Vector3 (x, y, z), Quaternion.identity) as GameObject;
					block.transform.parent = this.transform;
					SetColor (block);
					block.name = "Vector3" + block.transform.position + " - " + block.GetComponent<Renderer>().material.color;
				}
			}
		}
	}

	void Update () {
		
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
