using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameObject _asteroid;

	#endregion

	#region Methods
	public void SpawnAsteroid()
	{
		GameObject spawnedAsteroid = Instantiate(_asteroid, transform.position, Quaternion.identity);
		spawnedAsteroid.SetActive(true);
	}
	#endregion
}
