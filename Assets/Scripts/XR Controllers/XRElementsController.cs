using UnityEngine;

/// <summary>
/// Controller for the XR elements that we need to access on multiple scripts often and avoid repeat code or same editor references
/// </summary>
public class XRElementsController : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameObject _player;
	[SerializeField] private GameObject _leftHand;
	[SerializeField] private GameObject _rightHand;
	private static XRElementsController _instance;

	#endregion

	#region Properties
	public GameObject Player => _player;
	public GameObject LeftHand => _leftHand;
	public GameObject RightHand => _rightHand;
	public static XRElementsController Instance
	{
		get
		{
			return _instance;
		}
	}
	#endregion

	#region Unity Callbacks
	private void Awake()
	{
		if (_instance && _instance != this)
			Destroy(_instance);

		_instance = this;
	}

	#endregion

	#region Methods

	#endregion
}
