using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {
	private VideoPlayer _videoPlayer;

	public event Action<float, double> Rewinded;
	public event Action<float, double> FastForwarded;
	public event Action Paused;
	public event Action Played;
	public event Action Completed;

	void Start() {
		StartCoroutine(PlayVideo());
		_videoPlayer.loopPointReached += VideoComplete;
	}

	IEnumerator PlayVideo() {
		_videoPlayer = GetComponent<VideoPlayer>();
		_videoPlayer.Prepare();

		while (!_videoPlayer.isPrepared) {
			yield return null;
		}
	}

	public void Play() {
		_videoPlayer.Play();
		Played?.Invoke();
	}

	public void Pause() {
		_videoPlayer.Pause();
		Paused?.Invoke();
	}

	public void AddTime(double seconds) {
        if (_videoPlayer.time + seconds > _videoPlayer.length) {
            seconds = _videoPlayer.length - _videoPlayer.time;
        }
		_videoPlayer.time += seconds;
	}

	public void VideoComplete(VideoPlayer source) {
		Completed?.Invoke();
		source.Stop();
	}

	public void Rewind(float seconds) {
        _videoPlayer.Pause();
		AddTime(-seconds);
		Rewinded?.Invoke(seconds, _videoPlayer.time);
	}

	public void FastForward(float seconds) {
        _videoPlayer.Pause();
		AddTime(seconds);
		FastForwarded?.Invoke(seconds, _videoPlayer.time);
	}
}