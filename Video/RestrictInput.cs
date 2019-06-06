using UnityEngine;
using UnityEngine.SceneManagement;

public class RestrictInput : MonoBehaviour {
    private SceneManager _manager;
    [SerializeField]
    private VideoControllerInput _input;
    private SceneSwitching[] _scene;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if(_scene[0] == null) _input.enabled = false;
        SceneManager.activeSceneChanged += SceneChanged;
    }

    private void SceneChanged(Scene current, Scene next) {
        if (next.name == "WitnessStatement") {
            _scene = Resources.FindObjectsOfTypeAll<SceneSwitching>();
            _scene[0].Retryed += EnableVideoInput;
        }
    }

	private void EnableVideoInput() {
        _input = GameObject.Find("Video player")
            .GetComponent<VideoControllerInput>();
        _input.enabled = true;
	}
}