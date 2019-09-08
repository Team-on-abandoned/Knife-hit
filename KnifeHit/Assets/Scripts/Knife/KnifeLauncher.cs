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
		maxShoots = leftShoots = 0;
		isCanShoot = false;

		EventManager.OnNewTarget += OnNewTarget;
		EventManager.OnKnifeHit += OnKnifeHit;
		EventManager.OnTargetHit += OnTargetHit;
	}

	void OnDestroy() {
		EventManager.OnNewTarget -= OnNewTarget;
		EventManager.OnKnifeHit -= OnKnifeHit;
		EventManager.OnTargetHit -= OnTargetHit;
	}

	void OnMouseDown() {
		ShootKnife();
	}

	void OnNewTarget(EventData ed) {
		maxShoots = leftShoots = (int)(ed?["maxShoots"] ?? 1);
		SpawnKnife(true);
	}

	void OnKnifeHit(EventData ed) {
		isCanShoot = false;
	}

	void OnTargetHit(EventData ed) {
		SpawnKnife(false);
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
