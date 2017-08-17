using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

    [Tooltip ("The number of game minutes that pass per real second.")]
    public float minutesPerSecond = 60f;
	
	// Update is called once per frame
	void Update () {
        float angleThisFrame = Time.deltaTime / 360 * minutesPerSecond;
        transform.RotateAround(transform.position, Vector3.forward, angleThisFrame);
    }
}
