using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public Transform spawnPointsParent;
    public bool respawnPlayer = false;

    private Transform[] spawnPoints;
    private bool lastToggle = false;

    public void Start() {
        spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>();
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
}
