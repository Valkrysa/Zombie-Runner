using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {
    
    [Tooltip ("How many seconds the player must wait while being in a clear area to call the helicopter.")]
    public float waitTimeToTriggerHelicopter = 1f;
    
    private float timeSinceLastTrigger = 0f;
    private bool foundClearArea = false;
	
	void Update () {
        timeSinceLastTrigger += Time.deltaTime;

        if (timeSinceLastTrigger > waitTimeToTriggerHelicopter && Time.realtimeSinceStartup > 10f && !foundClearArea) {
            SendMessageUpwards("OnFindClearArea");
            foundClearArea = true;
        }
    }

    void OnTriggerExit (Collider collider) {
        if (collider.tag != "Player") {
            timeSinceLastTrigger = 0f;
        }
    }

    void OnTriggerEnter (Collider collider) {
        if (collider.tag != "Player") {
            timeSinceLastTrigger = 0f;
        }
    }

    void OnTriggerStay (Collider collider) {
        if (collider.tag != "Player") {
            timeSinceLastTrigger = 0f;
        }
    }
}
