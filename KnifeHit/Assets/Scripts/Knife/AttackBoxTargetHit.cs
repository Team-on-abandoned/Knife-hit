using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxTargetHit : MonoBehaviour {
	public Knife knife;

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Target") {
			knife.Stop();
			knife.transform.parent = collision.transform;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Target") {
			knife.Stop();
			knife.transform.parent = collision.transform;
		}
	}
}
