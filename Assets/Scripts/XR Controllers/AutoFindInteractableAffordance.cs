using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.State;

public class AutoFindInteractableAffordance : MonoBehaviour
{
	#region Unity Callbacks
	private void Awake()
	{
		GetComponent<XRInteractableAffordanceStateProvider>().interactableSource = GetComponentInParent<XRBaseInteractable>();
	}
	#endregion
}
