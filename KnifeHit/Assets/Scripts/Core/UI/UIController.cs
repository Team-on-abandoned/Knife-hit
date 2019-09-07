using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
	public enum CurrMenuEnum : byte { MainMenu, KnifeSelectMenu, LoseMenu, InGameMenu, GlobalUI }
	CurrMenuEnum CurrMenu;

	[SerializeField] UIScreen MainMenu;
	[SerializeField] UIScreen KnifeSelectMenu;
	[SerializeField] UIScreen LoseMenu;
	[SerializeField] UIScreen InGameMenu;
	[SerializeField] UIScreen GlobalUI;

	private void Awake() {
		CurrMenu = CurrMenuEnum.MainMenu;
	}
}
