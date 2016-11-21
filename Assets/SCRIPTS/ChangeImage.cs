using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeImage : MonoBehaviour {


	public bool clicked;

	// Use this for initialization
	void Start () {
		clicked = false;
	}



	public void EnableControls (GameObject image){


		image.SetActive(true);
		clicked = true; 

	}
		
}
