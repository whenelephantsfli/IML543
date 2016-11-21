using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	[SerializeField]
	private Transform player;

	NavMeshAgent nav;

	public float stopDistance;
	bool far;

	// Use this for initialization
	void Start () {
	
	player = GameObject.FindWithTag ("Player").transform;
	nav = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {

		far = (Vector3.Distance (player.transform.position, gameObject.transform.position) > stopDistance);


		if (far) {
		nav.SetDestination (player.transform.position);

		}

		else{

		 	nav.SetDestination (gameObject.transform.position);

		}
	
	}
}
