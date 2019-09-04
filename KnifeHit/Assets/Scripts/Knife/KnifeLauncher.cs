using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeLauncher : MonoBehaviour {
	public GameObject KnifePrefab;

	[SerializeField] GameObject CurrKnife;

	void Start() {
		SpawnKnife();
	}

	void Update() {

	}

	void OnMouseDown() {
		ShootKnife();
		SpawnKnife();
	}

	void ShootKnife() {
		if(CurrKnife != null) {
			CurrKnife.GetComponent<Knife>().Shoot();
			CurrKnife = null;
		}
	}

	void SpawnKnife() {
		if(CurrKnife == null)
			CurrKnife = Instantiate(KnifePrefab);
	}
}
