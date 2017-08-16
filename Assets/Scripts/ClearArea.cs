using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {
    
    [Tooltip ("How many seconds the player must wait while being in a clear area to call the helicopter.")]
    public float waitTimeToTriggerHelicopter = 1f;
    
    private float timeSinceLastTrigger = 0f;
    
	void Start () {
        timeSinceLastTrigger = Time.time;
    }
	
	void Update () {
        timeSinceLastTrigger += Time.deltaTime;

        if (timeSinceLastTrigger > waitTimeToTriggerHelicopter && Time.realtimeSinceStartup > 10f) {
            SendMessageUpwards("OnFindClearArea");
        }
    }

    void OnTriggerExit () {
        timeSinceLastTrigger = 0f;
    }

    void OnTriggerEnter () {
        timeSinceLastTrigger = 0f;
    }

    void OnTriggerStay () {
        timeSinceLastTrigger = 0f;
    }
}
