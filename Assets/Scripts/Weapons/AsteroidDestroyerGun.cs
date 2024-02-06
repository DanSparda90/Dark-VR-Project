using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Controller of the AsteroidDestroyerGun: Shoot lasers that can destroy asteroids.
/// </summary>
public class AsteroidDestroyerGun : MonoBehaviour
{
	#region Fields
	[Header("Effects")]
	[SerializeField] private ParticleSystem _particles;
	[SerializeField] private GameObject _laserBullet;

	[Header("Shoot Parameters")]
	[SerializeField] private Transform _shootSource;

	private AudioSource _audioSrc;

	#endregion

	#region Unity Callbacks
	void Start()
	{
		_audioSrc = GetComponent<AudioSource>();

		XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
		grabInteractable.activated.AddListener(StartShoot);
	}

	#endregion

	#region Methods
	private void StartShoot(ActivateEventArgs args)
	{
		GameObject laser = Instantiate(_laserBullet);
		laser.transform.position = _shootSource.position;
		laser.transform.forward = _shootSource.transform.forward;
		_audioSrc.Play();
	}
	
	#endregion


}
