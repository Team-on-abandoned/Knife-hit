using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;

public class Banner : MonoBehaviour {
	public string BannerId;
	public BannerPosition BannerPosition;

	void Start() {
		StartCoroutine(ShowBannerWhenReady());
	}

	IEnumerator ShowBannerWhenReady() {
		while (!Advertisement.IsReady(BannerId))
			yield return new WaitForSeconds(0.5f);

		Advertisement.Banner.Show(BannerId);
		Advertisement.Banner.SetPosition(BannerPosition);

		yield return null;

		Destroy(gameObject);
	}
}
