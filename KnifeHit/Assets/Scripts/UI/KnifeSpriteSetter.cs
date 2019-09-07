using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeSpriteSetter : MonoBehaviour {
	[SerializeField] Image image;

	void Start() {
		image.sprite = GameManager.Instance.Data.UsedPlayerKnifeSprite;
	}
}
