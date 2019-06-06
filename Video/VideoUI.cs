using UnityEngine;

public class VideoUI : MonoBehaviour {
    private VideoController _video;
	[SerializeField]
	private UISystem _uiSystem;

    void Start() {
        _video = GameObject.Find("Video player").GetComponent<VideoController>();
        _video.Rewinded += OnRewind;
        _video.FastForwarded += OnFastForward;
		_video.Paused += OnPaused;
		_video.Played += OnPlayed;
    }

    private void OnRewind(float rewindSeconds, double videoTime) {
		_uiSystem.ShowUI(UIStates.Rewind);
    }

    private void OnFastForward(float fastForwardSpeed, double videoTime) {
		_uiSystem.ShowUI(UIStates.FastForward);
    }

	private void OnPaused() {
		_uiSystem.ShowUI(UIStates.Pause);
	}

	private void OnPlayed() {
		_uiSystem.Hide();
	}
}
