using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gorillaBoss : MonoBehaviour {

    public BossDamageTaker head;
    public Animator anim;

    public bool dead;

	// Use this for initialization
	void Start () {
        head = GetComponent<BossDamageTaker>();
        anim = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (head.maxHealth <= 0 && !dead)
        {
            anim.SetTrigger("dead");
            dead = true;
        }
	}
}
