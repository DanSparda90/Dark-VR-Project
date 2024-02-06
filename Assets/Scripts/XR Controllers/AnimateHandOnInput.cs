using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controls the hand animation by the input of the player
/// </summary>
public class AnimateHandOnInput : MonoBehaviour
{
	#region Fields
	[SerializeField] private InputActionProperty _pinchAnimationAction;
    [SerializeField] private InputActionProperty _gripAnimationAction;
    [SerializeField] private Animator _handAnimator;

	#endregion

	#region Unity Callbacks

	void Update()
    {
        float triggerValue = _pinchAnimationAction.action.ReadValue<float>();
        _handAnimator.SetFloat("Trigger", triggerValue);

        float gripValue = _gripAnimationAction.action.ReadValue<float>();
        _handAnimator.SetFloat("Grip", gripValue);
    }

	#endregion
}
