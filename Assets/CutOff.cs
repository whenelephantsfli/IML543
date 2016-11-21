using UnityEngine;
using System.Collections;


public class CutOff : MonoBehaviour {
	bool disable = false;
	//GameObject door; 

	AudioSource audio; 

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other){
	

		if (other.CompareTag ("Player")) {
			gameObject.GetComponent<BoxCollider> ().isTrigger = false;

			//call door close 

			GetComponentInChildren<OpenDoor> ().Close ();
			print ("SHWSDFSDFSDF SCLOSE");
			audio.Play ();

		}
	}

}
