using UnityEngine;
using UnityEngine.UI;

public class PositionControlWithWatson : MonoBehaviour {
	private GameObject output;
	private Vector3 position;

	void Start () {
		output = GameObject.Find ("/TestSpeechToText/SpeechDisplayWidget/Output");
	}

	void Update () {
		position = this.transform.position;
		Text outputText = output.GetComponent<Text>();
		if (outputText.text.Contains ("Final")) {
//			Debug.Log (outputText.text);
			if (outputText.text.Contains ("前")) {
				transform.position = new Vector3 (position.x, position.y, position.z + 2);
			}
			if (outputText.text.Contains ("後")) {
				transform.position = new Vector3 (position.x, position.y, position.z - 2);
			}
			if (outputText.text.Contains ("右")) {
				transform.position = new Vector3 (position.x + 2, position.y, position.z);
			}
			if (outputText.text.Contains ("左")) {
				transform.position = new Vector3 (position.x - 2, position.y, position.z);
			}
			outputText.text = "reset";
		}
	}
}