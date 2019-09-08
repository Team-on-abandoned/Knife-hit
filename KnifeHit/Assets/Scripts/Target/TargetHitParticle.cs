using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitParticle : MonoBehaviour {
	[SerializeField] GameObject ParticlePrefab;

	void Awake() {
		EventManager.OnTargetHit += OnTargetHit;
	}

	void OnDestroy() {
		EventManager.OnTargetHit -= OnTargetHit;
	}

	void OnTargetHit(EventData eventData) {
		ParticleSystem particle = Instantiate(ParticlePrefab, new Vector3(0, 0.86f, -1), Quaternion.identity, transform).GetComponent<ParticleSystem>();
		particle.Play();
	}
}
