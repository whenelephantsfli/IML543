using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIInventoryChange : MonoBehaviour
{


	public static UIInventoryChange instance = null;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	public void ChangeSpriteImage (Sprite sprite)
	{
		GetComponent<Image> ().sprite = sprite;
	}

	public void DisplayImageRight ()
	{
		GetComponent<Image> ().enabled = true;

	}

	public void DisplayImageLeft ()
	{
		GetComponent<Image> ().enabled = true;


	}

}