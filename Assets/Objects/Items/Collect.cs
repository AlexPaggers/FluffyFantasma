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
			StartCoroutine(DestroyOnceEffectsHaveFinished());
		}
	}

	private void CollectedAudio()
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
