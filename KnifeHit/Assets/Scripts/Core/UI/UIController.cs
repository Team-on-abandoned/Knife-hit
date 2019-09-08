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
		currScreen?.Hide(false);
		InGameMenu.Show(false);
		currScreen = InGameMenu;

		GameManager.Instance.EventManager.CallOnGameStart();
	}

	public void ToKnifeSelectMenu() {
		currScreen?.Hide(false);
		KnifeSelectMenu.Show(false);
		currScreen = KnifeSelectMenu;
	}
}
