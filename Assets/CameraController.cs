using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private PlayerController player; 

	// Use this for initialization
	void Start () {

		player = GameObject.FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = player.transform.position + transform.up * .5f;

		//set camera and player forward 
		transform.forward = player.transform.forward; 
	}
}
