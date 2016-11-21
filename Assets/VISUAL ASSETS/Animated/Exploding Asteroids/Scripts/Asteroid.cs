using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

    public bool useUnityTriggers = true;
    public string[] triggeringTags; // Which tags will trigger the explosion
    public string[] triggeringNames; // Which names will trigger the explosion

    //private Rigidbody

	public Vector3 initialVelocity = Vector3.zero;
	public Vector3 initialRotationSpeed = Vector3.zero;
	
	private Vector3 velocity = Vector3.zero;
	private Vector3 rotationSpeed = Vector3.zero;
	
	public AsteroidCrackedBit[] crackedBitsPrefabs;
	public int minimumNumberOfBits = 4;
	public int maximumNumberOfBits = 8;
	
	public DustCloud[] dustPrefabs;
	
	public int startingLife = 100;
	private int life;

	AudioSource au;
	bool playSoundAndDestroy = false;

	void Start () {
		life = startingLife;
		velocity = initialVelocity;
		rotationSpeed = initialRotationSpeed;
		if(maximumNumberOfBits < minimumNumberOfBits)
		{
			Debug.LogWarning(name+": maximum number of bits is LESS than minimum number of bits, which makes no sense. Now both set to "+minimumNumberOfBits);
			maximumNumberOfBits = minimumNumberOfBits;
		}

        if (useUnityTriggers)
        {
            if (!GetComponent<Rigidbody>())
                gameObject.AddComponent<Rigidbody>();
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
            if (!GetComponent<Collider>())
                gameObject.AddComponent<BoxCollider>();
            GetComponent<Collider>().isTrigger = true;
        }

		au = GetComponent<AudioSource>();
	}
	
	void Update () {
		if(!playSoundAndDestroy)
		{
			Vector3 pos = transform.position;
			pos += velocity * Time.deltaTime;
			transform.position = pos;
			
			transform.Rotate (rotationSpeed);
		}
		else
		{
			if(!au.isPlaying)
			{
				Destroy(this.gameObject);
				Destroy(this);
			}
		}
	}
	
	public void explode()
	{
		// prevent calling explode if already marked for destruction
		if(playSoundAndDestroy)
			return;

		if(crackedBitsPrefabs.Length == 0)
		{
			Debug.LogWarning(name+": Cracked Bits Prefab is not set.");
			return;
		}
		else
		{
			// Create bits
			int numberOfBits = Random.Range(minimumNumberOfBits, maximumNumberOfBits);
			for(int i=0; i<numberOfBits; i++)
			{
				AsteroidCrackedBit a = (AsteroidCrackedBit) Instantiate(
					crackedBitsPrefabs[Random.Range (0,crackedBitsPrefabs.Length)],
					transform.position,
					transform.rotation);
				a.setVelocity ((new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f)) * 0.1f));
				a.transform.localScale *= Random.Range(0.5f,1f);
			}
			
			// Create Dust Clouds
			for(int i=0; i<dustPrefabs.Length; i++)
			{
				DustCloud d = (DustCloud) Instantiate(
					dustPrefabs[i],
					transform.position,
					transform.rotation);
			}

			// If audiosource present, destroy this object later
			if(au != null)
			{
				transform.GetChild(0).gameObject.SetActive(false);
				Debug.Log(transform.GetChild(0).name);
				au.Play ();
				GetComponent<BoxCollider>().enabled = false;
				Destroy (GetComponent<Rigidbody>());
				playSoundAndDestroy = true;
			}
			else
			{
				Destroy(this.gameObject);
				Destroy(this);
			}
		}
	}
	
	public void hit(int damage)
	{
		life -= damage;
		if(life<=0)
		{
			explode();
		}
	}

    void OnTriggerEnter(Collider c)
    {
        bool tagOK = false, nameOK = false;

        if (triggeringTags.Length > 0)
        {
            for (int i = 0; i < triggeringTags.Length; i++)
            {
                if (triggeringTags[i] == c.tag)
                    tagOK = true;
            }
        }
        else
        {
            tagOK = true;
        }

        if (triggeringNames.Length > 0)
        {
            for (int i = 0; i < triggeringNames.Length; i++)
            {
                if (triggeringNames[i] == c.name)
                    nameOK = true;
            }
        }
        else
        {
            nameOK = true;
        }
        
        if(tagOK && nameOK)
            explode();
    }

}
