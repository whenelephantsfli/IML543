using UnityEngine;
using System.Collections;

public class AudioTime : MonoBehaviour {
	AudioSource lost;
	// Use this for initialization
	void Start () {
		lost = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//print("Time " + lost.time);
	}
}
