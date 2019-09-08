using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {
	[SerializeField] GameObject[] TargetPrefabs;

	BaseTarget currTargetGameObject;
	int currTarget;


	void Awake() {
		EventManager.OnGameStart += OnGameStart;
		EventManager.OnAllKnifesShoot += OnAllKnifesShoot;
		EventManager.OnKnifeHit += OnKnifeHit;
	}

	void OnDestroy() {
		EventManager.OnGameStart -= OnGameStart;
		EventManager.OnAllKnifesShoot -= OnAllKnifesShoot;
		EventManager.OnKnifeHit -= OnKnifeHit;
	}

	void OnGameStart(EventData eventData) {
		if(currTargetGameObject != null)
			Destroy(currTargetGameObject.gameObject);
		currTarget = 0;
		SpawnTarget();
	}

	void OnAllKnifesShoot(EventData eventData) {
		++currTarget;
		//Call cool destroy animation
		Destroy(currTargetGameObject.gameObject);
		currTargetGameObject = null;
		//Call after animation
		LeanTween.delayedCall(UIConsts.menuAnimationsTime, () => {
			SpawnTarget();
		});
	}

	void OnKnifeHit(EventData eventData) {
		//Destroy(currTargetGameObject.gameObject, UIConsts.menuAnimationsTime * 2);
		//currTargetGameObject = null;
	}

	void SpawnTarget() {
		if (currTarget < TargetPrefabs.Length) {
			currTargetGameObject = Instantiate(TargetPrefabs[currTarget], transform).GetComponent<BaseTarget>();
		}
		else {
			currTargetGameObject = Instantiate(TargetPrefabs[Random.Range(0, TargetPrefabs.Length)], transform).GetComponent<BaseTarget>();
		}

		EventData eventData = new EventData("OnNewTarget");
		eventData["maxShoots"] = currTargetGameObject.NeededShoots;
		GameManager.Instance.EventManager.CallOnNewTarget(eventData);
	}
}
