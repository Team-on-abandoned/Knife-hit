using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_1 : BaseTarget {
	void Start() {

	}

	void Update() {
		transform.transform.Rotate(new Vector3(0, 0, 90 * Time.deltaTime));
	}
}
