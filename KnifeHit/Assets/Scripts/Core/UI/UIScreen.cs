using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour {
	[SerializeField] protected CanvasGroup canvasGroup;

	public void Show(bool isForce) {
		LeanTween.cancel(gameObject, false);

		if (!isForce) {
			LeanTween.value(gameObject, canvasGroup.alpha, 1, UIConsts.menuAnimationsTime)
			.setOnUpdate((a) => {
				canvasGroup.alpha = a;
			})
			.setOnComplete(() => {
				canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
			});
		}
		else {
			canvasGroup.alpha = 1.0f;
			canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
		}

		
	}

	public void Hide(bool isForce) {
		LeanTween.cancel(gameObject, false);

		if (!isForce) {
			LeanTween.value(gameObject, canvasGroup.alpha, 0, UIConsts.menuAnimationsTime)
			.setOnUpdate((a) => {
				canvasGroup.alpha = a;
			})
			.setOnComplete(() => {
				canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
			});
		}
		else {
			canvasGroup.alpha = 0.0f;
			canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
		}
	}
}
