using UnityEngine;
using System.Collections;

public class AwakenAgent : MonoBehaviour {

	AudioSource audio; 

	private Transform playerTrans = null;


	public AudioClip start;
	public AudioClip choosen;
	public AudioClip forest;
	//public GameObject forestDoor;
	public AudioClip poly;
	public AudioClip fish;
	public AudioClip hollywood;
	public AudioClip space;
	public AudioClip brian;
	public AudioClip caution;

	FollowPlayer follow;
	NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		playerTrans = GameObject.FindGameObjectWithTag ("Player").transform; 
		//follow = GetComponents<FollowPlayer>();
		//nav = GetComponents<NavMeshAgent>();

	
	}
	
	// Update is called once per frame
	public void PlayStartClip(){

		if (Vector3.Distance (playerTrans.position, this.transform.position) < 6f){
			audio.Play();
		}
	}

	public void PlayChosenClip(){

			audio.clip = choosen;
			audio.Play();
		}
		
	public void PlayForestClip(){

		audio.clip = forest;
		audio.Play();
	}


	public void PlaySpacelip(){

		audio.clip = space;
		audio.Play();
	}


	public void PlayPolyClip(){

		audio.clip = poly;
		audio.Play();
	}


	public void PlayFishClip(){

		audio.clip = fish;
		audio.Play();
	}

	public void PlayHollyClip(){

		audio.clip = hollywood;
		audio.Play();
	}


	public void PlayBrianClip(){

		audio.clip = brian;
		audio.Play();
	}




	public void Chosen(){
		GetComponent<FollowPlayer>().enabled = true; 
		GetComponent<NavMeshAgent>().enabled = true;

	}


	public void TurnOff(){

		audio.mute = true;

	}


}
	

