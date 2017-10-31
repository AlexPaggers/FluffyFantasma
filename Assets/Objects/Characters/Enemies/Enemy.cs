using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	private AudioSource source { get { return this.GetComponent<AudioSource>(); } }

	public GameObject coin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Bullet")
		{
			SpawnDrops();
			DeathAudio();
			StartCoroutine(DestroyOnceEffectsHaveFinished());

		}
	}

	private void SpawnDrops()
	{
		int total = Random.Range (2, 12);
		for (int i = 0; i < total; i++) 
		{
			//Instantiate (coin, this.transform, Quaternion.identity);

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
