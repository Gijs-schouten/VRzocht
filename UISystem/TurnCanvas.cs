using UnityEngine;

public class TurnCanvas : MonoBehaviour {
    [SerializeField]
	private AroundTargetRotator _aroundTargetRotator;
	private UISystem _UISystem;

	private void Start() {
		_UISystem = GetComponent<UISystem>();
		_UISystem.UIShown += RotateObject;
	}

	private void RotateObject() {
		_aroundTargetRotator.RotateAroundTarget();
	}
}
