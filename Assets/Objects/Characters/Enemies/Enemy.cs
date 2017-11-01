using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    int hits = 5;

	private AudioSource source { get { return this.GetComponent<AudioSource>(); } }

    public ParticleSystem particle;

    public GameObject player;

	public GameObject powerUp;
	public GameObject globe;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (player.transform.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
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
                Instantiate(particle, transform.position, transform.rotation);
                PlayerData.addScore(50);
                StartCoroutine(DestroyOnceEffectsHaveFinished());
            }
		}
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            DeathAudio();
            Instantiate(particle, transform.position, transform.rotation);
            StartCoroutine(DestroyOnceEffectsHaveFinished());
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
			if (!source.isPlaying)
				source.Play();

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
