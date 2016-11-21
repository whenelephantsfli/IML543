using UnityEngine;
using System.Collections;

public class AsteroidCrackedBit : MonoBehaviour {
	
	Vector3 velocity = Vector3.zero;
	Vector3 initialPosition = Vector3.zero;
	Vector3 rotationSpeed = Vector3.zero;
	public float maxRadius = 10f;
	
	
	void Start () {
		initialPosition = transform.position + new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f))*4f;
		rotationSpeed = new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f));
		transform.Rotate(rotationSpeed*10f);
	}
	
	void Update () {
		Vector3 pos = transform.position;
		pos.x += velocity.x;
		pos.y += velocity.y;
		pos.z += velocity.z;
		transform.position = pos;
		Vector3 dist = transform.position - initialPosition;
		if(dist.magnitude > maxRadius)
		{
			Destroy(this.gameObject);
			Destroy(this);
		}
		transform.Rotate (rotationSpeed);
	}
	
	public void setVelocity(Vector3 _velocity)
	{
		velocity = _velocity;
	}
	
}
