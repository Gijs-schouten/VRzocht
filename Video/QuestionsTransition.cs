using UnityEngine;

public class QuestionsTransition : MonoBehaviour {
	[SerializeField]
	private VideoController _videoController;
	[SerializeField]
	private LevelChanger _levelChanger;

	void Start() {
		_videoController.Completed += NextLevel;
	}

	private void NextLevel() {
		_levelChanger.NextLevelFader();
	}
}
