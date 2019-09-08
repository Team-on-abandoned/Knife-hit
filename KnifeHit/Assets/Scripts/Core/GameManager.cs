using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class GameManager : Singleton<GameManager> {
	//guarantee this will be always a singleton only
	protected GameManager() { }

	public EventManager EventManager;

	public GameManagerDataSO Data {
		get {
			if(data == null) {
				data = Resources.Load<GameManagerDataSO>("ScriptableObjects/GameManagerData");
			}
			return data;
		}
	}
	GameManagerDataSO data;

	public int CurrScore {
		get => _CurrScore;
		set {
			_CurrScore = value;
			EventManager.CallOnScoreChanged();
		}
	}
	public int CurrStage {
		get => _CurrStage;
		set {
			_CurrStage = value;
			EventManager.CallOnStageChanged();
		}
	}

	public int MaxScore {
		get {
			if (_MaxScore == -1)
				_MaxScore = PlayerPrefs.GetInt("GameManager._MaxScore", 0);
			return _MaxScore;
		}
		set {
			_MaxScore = value;
			EventManager.CallOnScoreChanged();
			PlayerPrefs.SetInt("GameManager._MaxScore", _MaxScore);
		}
	}
	public int MaxStage {
		get {
			if (_MaxStage == -1)
				_MaxStage = PlayerPrefs.GetInt("GameManager._MaxStage", 0);
			return _MaxStage;
		}
		set {
			_MaxStage = value;
			EventManager.CallOnStageChanged();
			PlayerPrefs.SetInt("GameManager._MaxStage", _MaxStage);
		}
	}
	int _CurrScore = -1;
	int _CurrStage = -1;
	int _MaxScore = -1;
	int _MaxStage = -1;

#if UNITY_ANDROID
	string gameId = "3284618";
#elif UNITY_IOS
	string gameId = "3284619";
#else
	string gameId = "1234567";
#endif
	bool isTestMode = true;

	void Awake() {
		Input.multiTouchEnabled = false;

		EventManager = new EventManager();

		EventManager.OnGameStart += OnGameStart;
		EventManager.OnTargetHit += OnTargetHit;
		EventManager.OnKnifeHit += OnKnifeHit;
		EventManager.OnAllKnifesShoot += OnAllKnifesShoot;
	}

	void Start() {
		Monetization.Initialize(gameId, isTestMode);
	}

	void OnDestroy() {
		EventManager.OnGameStart -= OnGameStart;
		EventManager.OnTargetHit -= OnTargetHit;
		EventManager.OnKnifeHit -= OnKnifeHit;
		EventManager.OnAllKnifesShoot -= OnAllKnifesShoot;
	}

	void OnGameStart(EventData eventData) {
		CurrScore = 0;
		CurrStage = 1;
	}

	void OnTargetHit(EventData eventData) {
		++CurrScore;
	}

	void OnKnifeHit(EventData eventData) {
		if (CurrScore > MaxScore)
			MaxScore = CurrScore;
		if (CurrStage > MaxStage)
			MaxStage = CurrStage;
	}

	void OnAllKnifesShoot(EventData eventData) {
		++CurrStage;
	}
}
