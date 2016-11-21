using UnityEngine;
using System.Collections;

public class AudioOn : MonoBehaviour {
	private GameObject gameObject;
	private AudioSource audioSource; 
	//public AudioClip audioClip; 
	// Use this for initialization
	void Start () {
		gameObject = GameObject.FindGameObjectWithTag("Audio");
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.Stop ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	void OnTriggerEnter(Collider other){
		//audioSource.clip = audioClip;

		if (other.tag == "MainCamera") {
			print ("trigger"); 
			audioSource.Play ();
		}
	}
}
