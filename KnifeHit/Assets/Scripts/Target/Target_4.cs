using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_4 : BaseTarget {
	public float speedMax = 360;
	public float speedStep = 90.0f;
	public float pauseTime = 1.0f;

	bool isGrow;
	float currSpeed;
	float currPause;

	void Awake() {
		currSpeed = 0;
		currPause = pauseTime;
		isGrow = true;
	}

	void Update() {
		if(currPause > 0) {
			currPause -= Time.deltaTime;
			if(currPause < 0) 
				currPause = 0;
			return;
		}

		transform.transform.Rotate(new Vector3(0, 0, currSpeed * Time.deltaTime));

		if (isGrow) {
			if (currSpeed < speedMax) {
				currSpeed += speedStep * Time.deltaTime;
				if (currSpeed > speedMax) {
					currSpeed = speedMax;
					isGrow = false;
				}
			}
		}
		else {
			if (currSpeed > 0) {
				currSpeed -= speedStep * Time.deltaTime;
				if (currSpeed < 0) {
					currSpeed = 0;
					isGrow = true;
					currPause = pauseTime;
				}
			}
		}
	}
}
