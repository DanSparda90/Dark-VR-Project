using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenWhenEnergyPutted : MonoBehaviour
{
	#region Fields
	[SerializeField] private Animator _animator;
	[SerializeField] private string _animBoolName = "Open";
	[SerializeField] AudioSource _audioSrc;

	#endregion

	#region Unity Callbacks
	private void Start()
	{
		GetComponent<XRSocketTagInteractor>().selectEntered.AddListener(DoorOpen);
		GetComponent<XRSocketTagInteractor>().selectExited.AddListener(DoorClose);
	}

	#endregion

	#region Methods
	private void DoorOpen(SelectEnterEventArgs args)
	{
		_animator.SetBool(_animBoolName, true);
		if(_audioSrc != null)
			_audioSrc.Play();

	}

	private void DoorClose(SelectExitEventArgs args)
	{
		_animator.SetBool(_animBoolName, false);
		if(_audioSrc != null)
			_audioSrc.Play();
	}
	#endregion
}
