using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    public AudioClip callSound;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private bool called = false;
    
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Call () {
        if (!called) {
            called = true;

            audioSource.clip = callSound;
            audioSource.Play();
            rigidBody.velocity = new Vector3(0, 0, 50f);
        }
    }
}
