using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

	private AudioSource source { get { return this.GetComponent<AudioSource>(); } }

	private void OnTriggerEnter2D(Collider2D other)
	{ 
		if(other.gameObject.tag == "Player")
		{
			CollectedAudio();
			CollectionEffect();
			StartCoroutine(DestroyOnceEffectsHaveFinished());
		}
	}

	private void CollectedAudio()
	{
	//	if (!source.isPlaying)
	//		source.Play();

		//re-add when audio is found
	}


	private void CollectionEffect()
	{
		switch (tag) 
		{
		case "Life":
		//	PlayerData.Lives++;
			break;
		case "Coin":
		//	PlayerData.Score += 10;
			break;
		}
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
