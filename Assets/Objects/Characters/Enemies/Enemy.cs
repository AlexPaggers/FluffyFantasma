using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	private AudioSource source { get { return this.GetComponent<AudioSource>(); } }

	public GameObject powerUp;
	public GameObject globe;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag == "Bullet")
		{
            SpawnDrops();
			DeathAudio();
			StartCoroutine(DestroyOnceEffectsHaveFinished());

		}
	}

	private void SpawnDrops()
	{
		int total = Random.Range (0, 4);
		for (int i = 0; i < total; i++) 
		{
			//gameObject.GetComponent<Spawner>().SpawnObject();
			if (i >= 3)
			{
				//	Instantiate(powerUp.transform, this.transform, Quaternion.identity);
				i += 3;
			}
			else 
			{
				//		Instantiate(globe.transform, this.transform, Quaternion.identity);
			}
		}

	}


	private void DeathAudio()
	{
		//	if (!source.isPlaying)
		//		source.Play();

		//re-add when audio is found
	}


	private IEnumerator DestroyOnceEffectsHaveFinished()
	{
		while (source.isPlaying)
		{
			yield return false;
		}
		Destroy(this.gameObject);
		yield return true;
	}
}
