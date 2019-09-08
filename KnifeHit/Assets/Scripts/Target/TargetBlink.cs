using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlink : MonoBehaviour {
	[SerializeField] SpriteRenderer SpriteRenderer;

	void Awake() {
		EventManager.OnTargetHit += OnTargetHit;
	}

	void OnDestroy() {
		LeanTween.cancel(gameObject, false);
		EventManager.OnTargetHit -= OnTargetHit;
	}

	void OnTargetHit(EventData eventData) {
		LeanTween.value(gameObject, 0.0f, 0.25f, 0.05f)
			.setOnUpdate((float val) => {
				SpriteRenderer.material.SetFloat("_FlashAmount", val);
			})
			.setOnComplete(()=> {
				LeanTween.value(gameObject, 0.25f, 0.0f, 0.05f)
				.setOnUpdate((float val) => {
					SpriteRenderer.material.SetFloat("_FlashAmount", val);
				});
			});
	}
}
