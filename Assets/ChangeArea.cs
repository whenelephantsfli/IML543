using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeArea : MonoBehaviour {


	[SerializeField]
	private GameObject _otherCurrentArea;

	[SerializeField]
	private List<GameObject> _listOfAreas = new List<GameObject>(); 

	[SerializeField]
	private GameObject _otherTrigger; 

	private int _randomAreaValue = 0; 



	void OnTriggerExit(Collider other){

	
		if (other.tag.Equals("Player")){


			GenerateNewArea();
			//rightCurrentArea = rightNextArea;
			print ("Hey im switching! left");
			gameObject.SetActive(false);
		
		}

	}

	void GenerateNewArea(){


		foreach(GameObject x in _listOfAreas)
		{
			x.SetActive(false);
		}

		_listOfAreas.Remove(_listOfAreas[_randomAreaValue]);

		_randomAreaValue = Random.Range(0, _listOfAreas.Count);


		_listOfAreas [_randomAreaValue].SetActive(true); 

		

	}

}
