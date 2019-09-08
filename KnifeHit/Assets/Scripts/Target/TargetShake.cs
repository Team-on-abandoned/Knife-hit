using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShake : MonoBehaviour {
	public float Speed = 0.0001f;

	Vector2 startPos;
	Coroutine shakeCoroutine;

	void Awake() {
		startPos = transform.position;

		EventManager.OnTargetHit += OnTargetHit;
	}

	void OnDestroy() {
		if(shakeCoroutine != null)
			StopCoroutine(shakeCoroutine);
		EventManager.OnTargetHit -= OnTargetHit;
	}

	void OnTargetHit(EventData eventData) {
		shakeCoroutine = StartCoroutine(ShakeCoroutine());
	}

	IEnumerator ShakeCoroutine() {
		for(byte i = 0; i < 5; ++i) {
			gameObject.transform.position = startPos + Random.insideUnitCircle * Speed * Time.deltaTime;
			yield return null;
		}
		gameObject.transform.position = startPos;
	}
}
