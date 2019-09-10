using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;

public class Banner : MonoBehaviour {
	public string BannerId;
	public BannerPosition BannerPosition;

	void Awake() {
		EventManager.OnAdsNeeded += OnAdsNeeded;
	}

	void OnDestroy() {
		EventManager.OnAdsNeeded -= OnAdsNeeded;
	}

	void OnAdsNeeded(EventData eventData) {
		Advertisement.Banner.Show(BannerId);
		Advertisement.Banner.SetPosition(BannerPosition);

		Destroy(gameObject);
	}
}
