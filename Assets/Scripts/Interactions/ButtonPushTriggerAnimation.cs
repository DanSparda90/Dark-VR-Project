using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushTriggerAnimation : MonoBehaviour
{
	#region Fields
	[SerializeField] private Animator _animator;
	[SerializeField] private string _animBoolName = "Activate";
	[SerializeField] private bool _isMakePlayerChild;
	[SerializeField] private AudioSource _audioSrc;

	private bool _isPlayerChild;
	private GameObject _player;

	#endregion

	#region Unity Callbacks
	private void Start()
	{
		_player = XRElementsController.Instance.Player;
		GetComponent<XRSimpleInteractable>().selectEntered.AddListener(ToggleAnimationActivation);
	}

	#endregion

	#region Methods
	private void ToggleAnimationActivation(SelectEnterEventArgs args)
	{
		bool isActivated = _animator.GetBool(_animBoolName);
		_animator.SetBool(_animBoolName, !isActivated);

		if (!isActivated && _isMakePlayerChild && !_isPlayerChild)
		{	
			_player.transform.SetParent(_animator.transform);
			_isPlayerChild = true;
		}

		if (_audioSrc != null)
			_audioSrc.Play();
	}
	#endregion
}
