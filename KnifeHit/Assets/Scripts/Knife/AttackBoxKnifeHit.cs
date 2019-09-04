using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxKnifeHit : MonoBehaviour {
	public Knife knife;

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "KnifeHitBox") {
			knife.Stop();
			knife.FallOnKnifeHit();
		}
	}
}
