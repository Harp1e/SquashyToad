using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogGaze : MonoBehaviour {

	public Text gazeText;

	private CardboardHead cardboardHead;

	// Use this for initialization
	void Start () {
		cardboardHead = GameObject.FindObjectOfType<CardboardHead>();
	}
	
	// Update is called once per frame
	void Update () {
		gazeText.text = cardboardHead.Gaze.ToString();
	}
}
