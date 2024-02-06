using UnityEngine;

public class Asteroid : MonoBehaviour
{
	#region Fields
	[SerializeField] private GameObject _explosionParticles;
	[SerializeField] private AudioClip _explosionSound;
	[SerializeField] private float _speed = 4f;
	[SerializeField] private Transform _player;

	#endregion

	#region Unity Callbacks
	void Update()
	{
		float step = _speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, _player.position, step);
	}


	private void OnCollisionEnter(Collision col)
	{
		
		if (col.gameObject.CompareTag("Ship"))
		{
			//Instantiate(_explosionOnShipParticles, transform.position, Quaternion.identity);
			//StartCoroutine(PlayExplosionSound());
			//GameControllerAsteroids.Instance.RestaVida();
			Destroy(gameObject);
		}
	}

	#endregion

	#region Methods
	public void DestructAsteroid(bool playDefaultSound = true)
	{
		Instantiate(_explosionParticles, transform.position, Quaternion.identity);

		if (playDefaultSound)
			PlayExplosionSound();

		Destroy(gameObject);		
	}

	private void PlayExplosionSound()
	{
		GameObject audio = new GameObject();
		audio.name = "audioAsteroidDestroyed";
		audio.transform.position = gameObject.transform.position;
		audio.AddComponent<DestroyByTime>();
		audio.GetComponent<DestroyByTime>().DestroyTime = 3f;
		audio.AddComponent<AudioSource>();
		audio.GetComponent<AudioSource>().clip = _explosionSound;
		audio.GetComponent<AudioSource>().spatialBlend = 1.0f;
		audio.GetComponent<AudioSource>().minDistance = 5000f;
		audio.GetComponent<AudioSource>().volume = 0.4f;
		audio.GetComponent<AudioSource>().Play();
	}
	#endregion
}