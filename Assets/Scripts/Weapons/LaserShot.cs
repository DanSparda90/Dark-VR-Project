using System.Collections;
using UnityEngine;

public class LaserShot: MonoBehaviour
{
	#region Fields
	[SerializeField] private float _speed = 4f;

	#endregion

	#region Unity Callbacks
	void Update()
	{
		transform.position = transform.position + _speed * (transform.forward) * Time.deltaTime;
	}

	#endregion

	#region Methods
	public void OnTriggerEnter(Collider col)
	{		
		if (col.tag == "Asteroid")
		{
			col.gameObject.GetComponent<Asteroid>().DestructAsteroid();
			Destroy(gameObject);
		}
		else
		{
			Destroy(gameObject);
			//TODO: decals and particles effects
		}
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Asteroid"))
		{
			col.gameObject.GetComponent<Asteroid>().DestructAsteroid();
			Destroy(gameObject);
		}
		else
		{
			Destroy(gameObject);
			//TODO: decals and particles effects
		}
	}

	#endregion
}
