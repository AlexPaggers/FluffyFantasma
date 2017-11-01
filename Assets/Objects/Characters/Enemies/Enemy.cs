using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    int hits = 5;

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
            hits--;
            if (hits == 0)
            {
                SpawnDrops();
                DeathAudio();
                StartCoroutine(DestroyOnceEffectsHaveFinished());
            }
		}
	}

	private void SpawnDrops()
	{

        if(Random.Range (0,5) < 4)
        {
            int total = Random.Range(1, 4);
            for (int i = 0; i < total; i++)
            {
                Instantiate(globe.transform, this.transform.position, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(powerUp.transform, this.transform.position, Quaternion.identity);
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
