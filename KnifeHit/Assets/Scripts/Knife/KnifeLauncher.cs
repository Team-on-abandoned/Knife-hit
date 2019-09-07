using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeLauncher : MonoBehaviour {
	public GameObject BottomBackground;
	public GameObject KnifePrefab;

	public int maxShoots;
	int leftShoots;

	GameObject CurrKnife;

	bool isCanShoot;

	private void Awake() {
		EventManager.OnTargetHit += OnTargetHit;

		//TODO: set maxShoots on level start
		//TODO: set target info
		//Call CallOnGameStart
		maxShoots = leftShoots = 5;

		EventData eventData = new EventData("eventData");
		eventData["maxShoots"] = maxShoots;
		GameManager.Instance.EventManager.CallOnGameStart(eventData);
	}

	void Start() {
		SpawnKnife(true);
	}

	void OnDestroy() {
		EventManager.OnTargetHit -= OnTargetHit;
	}

	void OnMouseDown() {
		ShootKnife();
	}

	void ShootKnife() {
		if(isCanShoot && CurrKnife != null && leftShoots > 0) {
			Knife knife = CurrKnife.GetComponent<Knife>();
			knife.Shoot();

			if(--leftShoots == 0) 
				knife.IsLastKnife = true;

			CurrKnife = null;
			GameManager.Instance.EventManager.CallOnKnifeShoot();
		}
	}

	void OnTargetHit(EventData ed) {
		SpawnKnife(false);
	}

	void SpawnKnife(bool isForce) {
		if(CurrKnife == null && leftShoots > 0) {
			if (isForce) {
				CurrKnife = Instantiate(KnifePrefab, transform.position, Quaternion.identity);
				isCanShoot = true;
			}
			else {
				CurrKnife = Instantiate(KnifePrefab, transform.position + new Vector3(0, -1.5f), Quaternion.identity);
				BottomBackground.SetActive(true);
				LeanTween.moveY(CurrKnife, transform.position.y, 0.1f)
					.setOnComplete(() => {
						isCanShoot = true;
						BottomBackground.SetActive(false);
					});
			}
		}
	}
}
