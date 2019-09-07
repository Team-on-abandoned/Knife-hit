using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
	const float speed = 1200.0f;

	public SpriteRenderer sr;
	public new Rigidbody2D rigidbody;

	public GameObject AttackBoxTarget;
	public GameObject AttackBoxKnife;
	public GameObject HitBox;

	public bool IsUsePlayerSprite;

	public bool IsLastKnife;

	bool isFall;

	private void Awake() {
		isFall = false;
		IsLastKnife = false;

		if (IsUsePlayerSprite)
			sr.sprite = GameManager.Instance.Data.UsedPlayerKnifeSprite;
	}

	public void Shoot() {
		rigidbody.AddForce(new Vector2(0, speed));
	}

	public void Stop() {
		rigidbody.velocity = Vector3.zero;
	}

	public void FallOnKnifeHit() {
		if (isFall)
			return;
		isFall = true;

		rigidbody.freezeRotation = false;
		rigidbody.AddForceAtPosition(new Vector2(1, 0), rigidbody.position + new Vector2(Random.Range(-0.5f, 0.5f), 0), ForceMode2D.Impulse);
		rigidbody.gravityScale = 1.0f;
		DisableColliders();
	}

	public void FallOnFinish() {

	}

	void DisableColliders() {
		AttackBoxTarget.SetActive(false);
		AttackBoxKnife.SetActive(false);
		HitBox.SetActive(false);
	}
}
