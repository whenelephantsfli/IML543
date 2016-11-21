using UnityEngine;
using System.Collections;

public class HopeChangeClip : MonoBehaviour {


	AudioSource audio; 

	public AudioClip start;
	public AudioClip choosen;
	public AudioClip forest;
	public GameObject forestDoor;
	public AudioClip poly;
	public AudioClip fish;
	public AudioClip hollywood;
	public AudioClip space;
	public AudioClip brian;
	public AudioClip caution;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		audio.clip = start;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}




}
