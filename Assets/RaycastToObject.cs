using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RaycastToObject : MonoBehaviour
{

	[SerializeField]
	private Image _crosshairImage;

	[SerializeField]
	private Sprite _onHoverSprite;
	[SerializeField]
	private Sprite _nonHoverSprite;

	[SerializeField]
	private Sprite _doorSprite;

	[SerializeField]
	private Sprite _agentSpeak;

	[SerializeField]
	private Sprite _rightInventorySprite;

	[SerializeField]
	private Sprite _leftInventorySprite;

	[SerializeField]
	private CurrentInventory _inventory;


	public AwakenAgent _hopeAudioClips;
	public AwakenAgent _skepAudioClips;
	public AwakenAgent _confiAudioClips;
	public AwakenAgent _choosenAudioClip;



	private Transform playerTrans = null;

	[SerializeField]
	private bool ImageOn;

	// Use this for initialization
	void Start ()
	{
		ImageOn = false; 
		playerTrans = GameObject.FindGameObjectWithTag ("Player").transform; 
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		ManageRaycast ();
		//print ((Vector3.Distance (playerTrans.position, this.transform.position))); 
	}

	void ManageRaycast ()
	{
		RaycastHit objectHit;  

		if (Vector3.Distance (playerTrans.position, this.transform.position) < 4f) {
			print ("DSFDFSDF");
			// Shoot raycast
			if (Physics.Raycast (transform.position, transform.forward, out objectHit, 50)) {
				//Debug.Log("Raycast hitted to: " + objectHit.collider);
				_crosshairImage.sprite = _nonHoverSprite;
				if (objectHit.transform.gameObject.tag == "InventoryObject") {
					_crosshairImage.sprite = _onHoverSprite;
					print ("InventoryObject");

					//Pick up object
					if (Input.GetMouseButtonDown (0)) {
						objectHit.transform.GetComponent<ItemTemplateClass> ().ChangeImageOnUI ();
						UIImageChangingScript.instance.DisplayImage ();
						//ImageOn = true;
						_crosshairImage.sprite = _nonHoverSprite;
					}

					if (Input.GetKeyDown (KeyCode.E)) {
						{
							_inventory.AddItemToRightHand (objectHit.transform.GetComponent<ItemTemplateClass> ());

							objectHit.transform.GetComponent<InventoryTemplate> ().ChangeImageOnUI ();
							UIInventoryChange.instance.DisplayImageRight ();
							//ImageOn = true;
							_crosshairImage.sprite = _nonHoverSprite;
						}

						if (Input.GetKeyDown (KeyCode.Q)) {

							_inventory.AddItemToLeftHand (objectHit.transform.GetComponent<ItemTemplateClass> ());
						}


					} else { 
						if (Input.GetMouseButtonDown (1)) {
							UIImageChangingScript.instance.HideImage ();

						}
					}
				} else {
			
					if (Input.GetMouseButtonDown (1)) {
						UIImageChangingScript.instance.HideImage ();
					}
				}

				if (Input.GetMouseButtonDown (1)) {
					UIImageChangingScript.instance.HideImage ();

				}


				if (objectHit.transform.gameObject.tag == "DoorObject") {
					_crosshairImage.sprite = _doorSprite;

				}
					if (objectHit.transform.gameObject.tag == "Hopeful") {
						_crosshairImage.sprite = _agentSpeak;


						if (Input.GetMouseButtonDown (0)) {

					
							_hopeAudioClips.PlayStartClip ();


						}


					if (Input.GetMouseButtonDown (1)) {

						_hopeAudioClips.PlayChosenClip ();
						_hopeAudioClips.Chosen();

						_confiAudioClips.TurnOff();
						_skepAudioClips.TurnOff();



						}
					}

					if (objectHit.transform.gameObject.tag == "Confident") {
						_crosshairImage.sprite = _agentSpeak;
		

						if (Input.GetMouseButtonDown (0)) {
							_confiAudioClips.PlayStartClip ();
						}

						if (Input.GetMouseButtonDown (1)) {
						
						_confiAudioClips.PlayChosenClip ();
						_confiAudioClips.Chosen();

						_skepAudioClips.TurnOff();
						_hopeAudioClips.TurnOff();


						}
					}

					if (objectHit.transform.gameObject.tag == "Skeptical") {
						_crosshairImage.sprite = _agentSpeak;
			

						if (Input.GetMouseButtonDown (0)) {
							_skepAudioClips.PlayStartClip ();

						}


					if (Input.GetMouseButtonDown (1)) {

						_skepAudioClips.PlayChosenClip ();
						_skepAudioClips.Chosen();

						_confiAudioClips.TurnOff();
						_hopeAudioClips.TurnOff();
							
					

						}

		
				}	
			}
		}
	}


}