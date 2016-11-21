using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//add cool skybox - biosensors
	public float moveSpeed = 5.0f;
	public float jumpPower = 10.0f;
	public float maxVelocityChange = 10.0f;

	private float movePower = 5.0f;
	private bool grounded = true;
	private Terrain terrain;

	//	private float oldTime = 0.0f;
	//	private float newTime = 0.0f;
	//	private int count = 0;

	// Use this for initialization
	public void StartATL () 
	{
		terrain = GameObject.FindObjectOfType<Terrain> ();
	}

	// Update is called once per frame
	public void UpdateATL () 
	{

		//		if ( grounded )AxKDebugLines.AddBounds (GetComponent< MeshRenderer > ().bounds, Color.green);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		if (transform.position.y < -10.0f) 
		{
			SceneManager.LoadScene ("Playground");
		}

		Vector3 raycastPos = transform.position - transform.up * transform.GetComponent<CapsuleCollider>().height / 3.0f;
		Vector3 targetPos = raycastPos - Vector3.up * transform.GetComponent<CapsuleCollider>().height / 3.0f; // goes out 2x diff from raycastPos to feet
		RaycastHit hit = new RaycastHit();

		Physics.Raycast(raycastPos, targetPos - raycastPos, out hit, Vector3.Distance(raycastPos, targetPos));

		Vector3 newForward = Vector3.Normalize( GetComponent< Rigidbody >().velocity * 2.0f + transform.forward );
		newForward.y = 0.0f;
		newForward = Vector3.Normalize (newForward);
		//resetting forward makes moving backward twisty. fix with newForward = transform.forward when moving backwards
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (newForward, Vector3.up), Time.deltaTime * 4.0f);

		Vector3 targetVelocity = new Vector3 (KeyToF (KeyCode.D) - KeyToF (KeyCode.A), 0.0f, KeyToF (KeyCode.W) - KeyToF (KeyCode.S));

		//calculate how fast we should be moving based on user input
		targetVelocity = Camera.main.transform.TransformDirection (targetVelocity);

		float moveSpeedMult = KeyToF (KeyCode.LeftShift) * 2.0f + 1.0f;
		targetVelocity *= moveSpeed * moveSpeedMult;

		//apply a force that attempts to reach our target velocity
		Vector3 velocity = GetComponent<Rigidbody>().velocity;
		Vector3 velocityChange = targetVelocity - velocity;
		velocityChange.x = Mathf.Clamp (velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0; 
		velocityChange.z = Mathf.Clamp (velocityChange.z, -maxVelocityChange, maxVelocityChange);
		GetComponent<Rigidbody> ().AddForce (velocityChange, ForceMode.VelocityChange);

		if (!grounded) 
		{
			return;
		}

		float thrust = KeyToF(KeyCode.Space, true) * jumpPower;
		GetComponent<Rigidbody> ().AddForce (transform.up * thrust, ForceMode.Impulse );

	}

	float KeyToF ( KeyCode keyCode, bool onDown = false )
	{
		if (onDown) 
		{ 
			return Input.GetKeyDown (keyCode) ? 1.0f : 0.0f; 

		} else 
		{
			return Input.GetKey (keyCode) ? 1.0f : 0.0f;
		}
	}

//	void OnCollisionExit(Collision collisionInfo) //why don't these register?
//	{
//		//		print (collisionInfo.collider);
//		if (collisionInfo.collider == terrain.GetComponent<TerrainCollider>()) 
//		{
//			print ("reg not grounded");
//			grounded = false;
//		}
//
//		//		newTime = Time.timeSinceLevelLoad;
//		//		if ((newTime - oldTime) >= 0.5f) {
//		//			grounded = false;
//		//		}
//		//		oldTime = newTime;
//
//	}
//
//	void OnCollisionEnter (Collision collisionInfo)
//	{
//		//		print (collisionInfo.collider);
//		if (collisionInfo.collider == terrain.GetComponent<TerrainCollider>()) 
//		{
//			print ("reg grounded");
//			grounded = true;
//		}
//	}

	//	//use for sound fx
	//	void OnCollisionStay(Collision collisionInfo) {
	//		foreach (ContactPoint contact in collisionInfo.contacts) {
	//			Debug.DrawRay(contact.point, contact.normal, Color.white);
	//			Vector3 playerFootPos = transform.position - transform.up *  ( transform.GetComponent< CapsuleCollider > ().height / 2.0f );
	//			AxKDebugLines.AddSphere (playerFootPos, 0.3f, Color.red);
	//			if ( Vector3.Distance( contact.point, playerFootPos ) < 0.3f ) 
	//			{
	//				if(Vector3.Dot(contact.normal, Vector3.up) > .5)
	//				{
	//					grounded = true;	
	//				}
	//			}
	//		}
	//	}
	//

}