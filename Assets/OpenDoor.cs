using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour
{

	public float doorOpenAngle = 90.0f;
	public float doorCloseAngle = 0f;
	public float doorAnimSpeed = 2.0f;
	private Quaternion doorOpen = Quaternion.identity;
	private Quaternion doorClose = Quaternion.identity;

	//public bool opened = false;

	AudioSource audio;
	public AudioClip open; 
	public AudioClip close; 

	private IEnumerator coroutine;

	private Transform playerTrans = null;
	public bool doorStatus = false;

	//false is close, true is open IMPORTANT 
	public bool isDoorOpen = false;
	public bool isDoorLocked = false;
	public bool inTransition = false;
	public bool goingForward = true; 


	//for Coroutine, when start only one
	public bool openedDoor = false;

	void Start ()
	{
		doorStatus = false; //door is open, maybe change MAY NOT USE 
		//Initialization your quaternions
		doorOpen = Quaternion.Euler (0, doorOpenAngle, 0);
		doorClose = Quaternion.Euler (0, doorCloseAngle, 0);
		//Find only one time your player and get him reference
		//playerTrans = GameObject.Find ("Player").transform;
		audio = GetComponent<AudioSource> ();

		playerTrans = GameObject.FindGameObjectWithTag ("Player").transform; 
	}


	void flipDoor(){
		isDoorOpen = !isDoorOpen;
		doorStatus = !doorStatus;
		//inTransition = false;
	}

	public bool slerpTo( Quaternion destination, float speed ) {
		if (Quaternion.Angle (transform.localRotation, destination) > 4f ) {
			transform.localRotation = Quaternion.Slerp (transform.localRotation, destination, Time.deltaTime * speed);
			print( "slerp still false:" );
			return false;
		}
		return true;
	}


	void Reset (){

			isDoorOpen = false;
			isDoorLocked = false;
			inTransition = false;
			goingForward = !goingForward; 
	}
	void Update ()
	{
		print("door state:" + isDoorOpen );
		print("inTransition:" + inTransition );
		//If press F key on keyboard
		if (!isDoorLocked && Input.GetMouseButtonDown (0)) {
			//Calculate distance between player and door
			//to open the door
			if (Vector3.Distance (playerTrans.position, this.transform.position) < 5f && !inTransition && !isDoorOpen ) {
					audio.clip = open;
					//audio.Play(); 
					inTransition = true;
	


				audio.Play(); 
					//StartCoroutine (this.moveDoor (doorOpen));
					//transform.localRotation = Quaternion.Slerp (transform.localRotation, doorOpen, Time.deltaTime * doorAnimSpeed);

				
				}
			}
		//transition to open door
		if( inTransition ) {
			print("in transition code:");
			if (!isDoorOpen){
				//isDoorOpen = slerpTo( doorOpen, doorAnim
				if ( slerpTo( doorOpen, doorAnimSpeed ) ){
					inTransition = false;
					//isDoorOpen = true;
					print("door state finished open" + isDoorOpen );
				}
			}
			else{
				print("slerpt to close:");
				if ( slerpTo( doorClose, 6.0f ) ) {
					inTransition = false;
					isDoorOpen = false;
					isDoorLocked = true;
					//enable the other collider 
				}
			}
		}//flip the state whatever it is
//		else{
//			flipDoor();
//		}
	}

	public IEnumerator moveDoor (Quaternion dest)
	{
		print("isDoorOpen =" + isDoorOpen);

		//isDoorOpen = true;
		//Check if close/open, if angle less 4 degree, or use another value more 0
		while (Quaternion.Angle (transform.localRotation, dest) > 4f) {
			//print ("moving the rotation: " + dest);
			transform.localRotation = Quaternion.Slerp (transform.localRotation, dest, Time.deltaTime * doorAnimSpeed);
			//UPDATE 1: add yield
			yield return null;
		}

		print("outloopie:isDoorOpen =" + isDoorOpen);

		//Change door status
		doorStatus = !doorStatus;
		// if close -> open , elseif open -> close
		isDoorOpen = !isDoorOpen;
		//isDoorOpen = false;
		//UPDATE 1: add yield
		yield return null;
		//StartCoroutine (WaitForDoor (3f));
	}

	public void Close ()
	{
		audio.clip = close;
		doorAnimSpeed = 6.0f; 
		//if (doorStatus) { //if door open
		if(isDoorOpen){
			StartCoroutine (this.moveDoor (doorClose));
			audio.Play ();
		}
		//print (" Door: Closed"); 
	}

	IEnumerator WaitForDoor (float waitTime)
	{
		
		yield return new WaitForSeconds (waitTime);
		//Close ();

	}

}
