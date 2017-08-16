using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Helicopter helicopter;
    public Transform spawnPointsParent;
    public AudioClip whatHappened;

    private AudioSource innerVoice;
    private bool respawnPlayer = false;
    private Transform[] spawnPoints;
    private bool lastToggle = false;

    public void Start() {
        spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>();

        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources) {
            if (audioSource.priority == 1) {
                innerVoice = audioSource;
            }
        }
        innerVoice.clip = whatHappened;
        innerVoice.Play();
    }

    void Update() {
        if (lastToggle != respawnPlayer) {
            respawnPlayer = false;
            ReSpawn();
        } else {
            lastToggle = respawnPlayer;
        }
    }

    public void ReSpawn () {
        int randomSpawnPoint = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[randomSpawnPoint].transform.position;
    }

    void OnFindClearArea () {
        helicopter.Call();
    }
}
