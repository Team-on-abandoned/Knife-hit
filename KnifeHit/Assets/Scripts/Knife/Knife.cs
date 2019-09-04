using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
	const float speed = 1200.0f;

	public SpriteRenderer sr;
	public new Rigidbody2D rigidbody;

	public bool IsUsePlayerSprite;

	private void Awake() {
		if (IsUsePlayerSprite)
			sr.sprite = GameManager.Instance.Data.UsedPlayerKnifeSprite;
	}

	void Start() {

	}

	void Update() {

	}

	public void Shoot() {
		rigidbody.AddForce(new Vector2(0, speed));
	}

	public void Stop() {
		rigidbody.velocity = Vector3.zero;
		rigidbody.Sleep();
	}

	public void FallOnKnifeHit() {

	}

	public void FallOnFinish() {

	}
}
