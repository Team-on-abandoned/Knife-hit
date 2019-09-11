using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_3 : BaseTarget {
	public float speedMax = 360;
	public float speedStep = 90.0f;

	bool isGrow;
	float currSpeed;

	void Awake() {
		currSpeed = 0;
		isGrow = true;
	}

	void Update() {
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
				}
			}
		}
	}
}
