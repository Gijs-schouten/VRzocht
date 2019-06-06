using System;
using UnityEngine;

public class UISystem : MonoBehaviour {
	
	[Serializable]
	private struct UIReference {
		public UIStates state;
		public GameObject target;
	}

	[SerializeField]
	private UIReference[] _references;

	private UIStates _currentState;

	private bool _isVisible;
	public bool IsVisible {
		get {
			return _isVisible;
		}
		private set {
			if (_isVisible != value) {
				if (value) {
					UIShown?.Invoke();
				} else {
					UIHidden?.Invoke();
				}
			}
			_isVisible = value;
		}
	}

	public event Action<UIStates> UIChanged;
	public event Action UIShown;
	public event Action UIHidden;

	public void ShowUI(UIStates newState) {
        if (newState == _currentState) {
            return;
        }
		ActivateUI(newState, true);
		HideUI(_currentState);
		_currentState = newState;
		IsVisible = true;
		UIChanged?.Invoke(_currentState);
	}

	public void HideUI(UIStates state) {
		ActivateUI(state, false);
	}

	public void Hide() {
		HideUI(_currentState);
		IsVisible = false;
        _currentState = UIStates.Idle;
	}

	private void ActivateUI(UIStates newState, bool isActive) {
		var reference = GetReference(newState);
		if (reference.target == null) {
			return;
		}
		reference.target.SetActive(isActive);
	}

	private UIReference GetReference(UIStates state) {
		UIReference foundReference = new UIReference();
		var l = _references.Length;
		for (int i = 0; i < l; i++) {
			if(_references[i].state == state) {
				foundReference = _references[i];
				break;
			}
		}

		return foundReference;
	}

}
