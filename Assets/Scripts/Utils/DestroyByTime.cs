using System.Collections;
using UnityEngine;

/// <summary>
/// Destroy the game object on the seconds putted on _destroyTime.
/// </summary>
public class DestroyByTime : MonoBehaviour
{
	#region Fields
	[SerializeField] private float _destroyTime = 2;

	#endregion

	#region Attributes
	public float DestroyTime
	{
		get
		{
			return _destroyTime;
		}
		set
		{
			_destroyTime = value;
		}
	}
	#endregion

	void Start()
	{
		StartCoroutine(DestroyOnSeconds(_destroyTime));
	}

	private IEnumerator DestroyOnSeconds(float time)
	{
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}
