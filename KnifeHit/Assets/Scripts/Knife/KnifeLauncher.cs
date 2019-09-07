using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeLauncher : MonoBehaviour {
	public GameObject BottomBackground;
	public GameObject KnifePrefab;

	GameObject CurrKnife;

	bool isCanShoot;

	private void Awake() {
		EventManager.OnTargetHit += OnTargetHit; 
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
		if(isCanShoot && CurrKnife != null) {
			CurrKnife.GetComponent<Knife>().Shoot();
			CurrKnife = null;
		}
	}

	void OnTargetHit(EventData ed) {
		SpawnKnife(false);
	}

	void SpawnKnife(bool isForce) {
		if(CurrKnife == null) {
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
