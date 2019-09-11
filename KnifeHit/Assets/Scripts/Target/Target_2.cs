using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_2 : BaseTarget {
	public float speed = -90.0f;

	void Update() {
		transform.transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
	}
}
