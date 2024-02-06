using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Call the OnEnterEvent when detect a object enters with a _targetTag tag
/// </summary>
public class GenericTrigger : MonoBehaviour
{
	#region Fields
	[SerializeField] private string _targetTag;

	#endregion

	#region Events
	public UnityEvent<GameObject> OnEnterEvent;
	
	#endregion

	#region Unity Callbacks
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag(_targetTag))
			OnEnterEvent.Invoke(other.gameObject);
	}

	#endregion
}
