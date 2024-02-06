using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System;

public class ButtonPushTriggerEvent : MonoBehaviour
{
	#region Fields
	[SerializeField] private UnityEvent _event;	

	#endregion

	#region Unity Callbacks
	private void Start()
	{

		if (_event == null)
			_event = new UnityEvent();	

		GetComponent<XRSimpleInteractable>().selectEntered.AddListener(ActivateEventToDo);
	}

	#endregion

	#region Methods
	private void ActivateEventToDo(SelectEnterEventArgs arg0)
	{
		_event.Invoke();
	}


	#endregion
}
