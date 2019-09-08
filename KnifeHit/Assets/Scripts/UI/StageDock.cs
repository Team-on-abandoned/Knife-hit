using UnityEngine;
using TMPro;

public class StageDock : MonoBehaviour {
	public bool IsShowMax; //false - show max value, true - show value for current run
	[SerializeField] TextMeshProUGUI Text;

	void Awake() {
		EventManager.OnStageChanged += OnStageChanged;
	}

	void Start() {
		OnStageChanged(null);
	}

	void OnDestroy() {
		EventManager.OnStageChanged -= OnStageChanged;
	}

	void OnStageChanged(EventData eventData) {
		Text.text = $"STAGE {(IsShowMax ? GameManager.Instance.MaxStage : GameManager.Instance.CurrStage)}";
	}
}
