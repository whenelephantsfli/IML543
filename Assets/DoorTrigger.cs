using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	public OpenDoor door; 
	public GameObject collider; 

	public AwakenAgent hopeAgent;
	public AwakenAgent confiAgent;
	public AwakenAgent skeptAgent;

	// Use this for initialization
	void Start () {
	 
		//door = GetComponentInChildren<OpenDoor>(); 
	}
	
	// Update is called once per frame
	void Update () {

	}




	void OnTriggerExit(Collider other){

		print ("collided with " + other.name + "tag:"+ other.tag);
		print( "state of door:" + door.isDoorOpen ) ;
		if (other.tag.Equals("Player")  && door.isDoorOpen == true ){
			door.inTransition = true;
			//door.isOpen
			//door.slerpToClose( 6.0f );
			//door.Close();
			print ("TriggerExited");
			DoorLocked();
			//gameObject.GetComponent<OpenDoor>().enabled = false;
				
		}

		if (this.gameObject.tag.Equals("ForestDoor")) {
			print ("ForestAudio");

			if (other.tag.Equals("Hopeful")){
			
			
			hopeAgent.PlayForestClip();

			}

			if (other.tag.Equals("Confident")){


			confiAgent.PlayForestClip();
			

			}

			if(other.tag.Equals("Skeptical")){

			skeptAgent.PlayForestClip();
			}

		}

		if (this.gameObject.tag.Equals("SpaceDoor")) {
			print ("SpaceAudio");

			if (other.tag.Equals("Hopeful")){
				hopeAgent.PlaySpacelip();

			}

			if (other.tag.Equals("Confident")){
				confiAgent.PlaySpacelip();
			}

			if(other.tag.Equals("Skeptical")){
				skeptAgent.PlaySpacelip();
			}
		}

		if (this.gameObject.tag.Equals("RoomDoor")){

			print ("Room Audio");

			if (other.tag.Equals("Hopeful")){
				hopeAgent.PlayBrianClip();

			}

			if (other.tag.Equals("Confident")){
				confiAgent.PlayBrianClip();
			}

			if(other.tag.Equals("Skeptical")){
				skeptAgent.PlayBrianClip();
			}
		}

		if (this.gameObject.tag.Equals("PolyDoor")){

			print ("Poly Audio");

			if (other.tag.Equals("Hopeful")){
				hopeAgent.PlayPolyClip();
			}

			if (other.tag.Equals("Confident")){
				confiAgent.PlayPolyClip();
			}

			if(other.tag.Equals("Skeptical")){
				skeptAgent.PlayPolyClip();
			}
			}


		if (this.gameObject.tag.Equals("HollywoodDoor")){

			print ("Holly Audio");

			if (other.tag.Equals("Hopeful")){
				hopeAgent.PlayHollyClip();
			}

			if (other.tag.Equals("Confident")){
				confiAgent.PlayHollyClip();
			}

			if(other.tag.Equals("Skeptical")){
				skeptAgent.PlayHollyClip();
			}
		}

		if (this.gameObject.tag.Equals("FishDoor")){

			print ("Fish Audio");

			if (other.tag.Equals("Hopeful")){
				hopeAgent.PlayFishClip();
			}

			if (other.tag.Equals("Confident")){
				confiAgent.PlayFishClip();
			}

			if(other.tag.Equals("Skeptical")){
				skeptAgent.PlayFishClip();
			}
		}

	}
	void DoorLocked(){

		//collider.GetComponent<BoxCollider> ().isTrigger = false;



	}

}
