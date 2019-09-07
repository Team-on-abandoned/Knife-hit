using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxTargetHit : MonoBehaviour {
	public Knife knife;

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Target") {
			knife.Stop();
			knife.transform.parent = collision.transform;

			if (!knife.IsLastKnife) {
				GameManager.Instance.EventManager.CallOnTargetHit();
			}
			else {
				EventData eventData = new EventData("CallOnTargetHit");
				eventData["knife"] = knife;
				GameManager.Instance.EventManager.CallOnTargetHit(eventData);
			}
		}
	}
}
