 	using UnityEngine;
using System.Collections;
//using UnityEditor.SceneManagement;


public class Restart : MonoBehaviour {
	bool stage1, stage2, stage3;

	// Use this for initialization
	void Start () {
		stage1 = false; 
		stage2 = false;
		stage3 = false; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit (Collider other) {

		if (other.CompareTag("Player")){
			print ("RESTART");
			Application.LoadLevel(0); 
			//stage1 = true; 

		} 
		//	Application.LoadLevel(Application.loadedLevel);
		if (other.CompareTag("Player") && stage1){
			print ("RESTART");
			Application.LoadLevel(2); 
		//stage2 = true; 

		} 

		if (other.CompareTag("Player") && stage2){
			print ("RESTART");
			//Application.LoadLevel(3); 
			//stage2 = true; 

		} 

		}

}



