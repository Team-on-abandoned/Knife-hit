using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
	//guarantee this will be always a singleton only
	protected GameManager() { }

	public EventManager EventManager;

	public GameMangerDataSO Data {
		get {
			if(data == null) {
				data = Resources.Load<GameMangerDataSO>("ScriptableObjects/GameMangerData");
			}
			return data;
		}
	}
	GameMangerDataSO data;

	void Awake() {
		Input.multiTouchEnabled = false;

		EventManager = new EventManager();
	}
}
