using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject flarePrefab;
    public Transform spawnPointsParent;
    
    private bool respawnPlayer = false;
    private Transform[] spawnPoints;
    private bool lastRespawnToggle = false;

    public void Start() {
        spawnPoints = spawnPointsParent.GetComponentsInChildren<Transform>();
    }

    void Update() {
        if (lastRespawnToggle != respawnPlayer) {
            respawnPlayer = false;
            ReSpawn();
        } else {
            lastRespawnToggle = respawnPlayer;
        }
    }

    public void ReSpawn () {
        int randomSpawnPoint = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[randomSpawnPoint].transform.position;
    }

    void OnFindClearArea () {
        Invoke("DropFlare", 3f);
    }

    void DropFlare () {
        Instantiate(flarePrefab, transform.position, transform.rotation);
    }
}
