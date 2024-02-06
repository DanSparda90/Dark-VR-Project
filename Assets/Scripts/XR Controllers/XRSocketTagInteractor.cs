using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractor : XRSocketInteractor
{
	#region Fields
	[SerializeField] private string _targetTag;

	#endregion

	#region Methods
	public override bool CanHover(IXRHoverInteractable interactable)
	{
		return base.CanHover(interactable) && interactable.transform.CompareTag(_targetTag);
	}

	public override bool CanSelect(IXRSelectInteractable interactable)
	{
		return base.CanSelect(interactable) && interactable.transform.CompareTag(_targetTag);
	}

	#endregion
}
