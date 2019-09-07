using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
	[SerializeField] UIScreen MainMenu;
	[SerializeField] UIScreen KnifeSelectMenu;
	[SerializeField] UIScreen LoseMenu;
	[SerializeField] UIScreen InGameMenu;
	[SerializeField] UIScreen GlobalUI;

	UIScreen currScreen;

	private void Awake() {
		MainMenu.Show(true);
		currScreen = MainMenu;
	}

	public void ToMainMenu() {
		currScreen?.Hide(false);
		MainMenu.Show(false);
		currScreen = MainMenu;
	}

	public void ToInGameMenu() {
		//TODO: set target info
		//Call CallOnGameStart
		EventData eventData = new EventData("eventData");
		eventData["maxShoots"] = 6;
		GameManager.Instance.EventManager.CallOnGameStart(eventData);

		currScreen?.Hide(false);
		InGameMenu.Show(false);
		currScreen = InGameMenu;
	}

	public void ToKnifeSelectMenu() {
		currScreen?.Hide(false);
		KnifeSelectMenu.Show(false);
		currScreen = KnifeSelectMenu;
	}
}
