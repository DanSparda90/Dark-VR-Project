using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Breakable object defines an object that can be broken in pieces on _timeToBreak time. The pieces are always childs of the main object.
/// </summary>
public class BreakableObject : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _timeToBreak = 2f;

	private Transform[] _breakablePieces;
	private float _timer = 0f;

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_breakablePieces = GetComponentsInChildren<Transform>(true);
	}

	#endregion

	#region Methods
	public void Break()
	{
		_timer += Time.deltaTime;

		if(_timer > _timeToBreak)
		{
			foreach (Transform piece in _breakablePieces)
			{
				piece.gameObject.SetActive(true);
				piece.parent = null;
			}

			gameObject.SetActive(false);
		}		
	}
	#endregion



}
