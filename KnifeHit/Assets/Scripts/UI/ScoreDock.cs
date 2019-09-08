using UnityEngine;
using TMPro;

public class ScoreDock : MonoBehaviour {
	public bool IsShowMax; //false - show max value, true - show value for current run
	[SerializeField] TextMeshProUGUI Text;

	void Awake() {
		EventManager.OnScoreChanged += OnScoreChanged;
	}

	void Start() {
		OnScoreChanged(null);
	}

	void OnDestroy() {
		EventManager.OnScoreChanged -= OnScoreChanged;
	}

	void OnScoreChanged(EventData eventData) {
		Text.text = $"SCORE {(IsShowMax ? GameManager.Instance.MaxScore : GameManager.Instance.CurrScore)}";
	}
}
