using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Controller of the FractureGun: Shoot, Stop and Raycast to call to break the object.
/// </summary>
public class FractureGun : MonoBehaviour
{
	#region Fields
	[Header("Effects")]
	[SerializeField] private ParticleSystem _particles;

	[Header("Shoot Parameters")]
	[SerializeField] private LayerMask _layerMask;
	[SerializeField] private Transform _shootSource;
	[SerializeField] private float _distance = 10;

	private bool _raycastEnabled = false;
	private AudioSource _audioSrc;

	#endregion

	#region Unity Callbacks
	void Start()
    {
		_audioSrc = GetComponent<AudioSource>();

        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(StartShoot);
        grabInteractable.deactivated.AddListener(StopShoot);
    }

	private void Update()
	{
		if(_raycastEnabled)
			RaycastCheck();
	}

	#endregion

	#region Methods
	private void StartShoot(ActivateEventArgs args)
	{
		_particles.Play();
		_raycastEnabled = true;
		_audioSrc.Play();
	}

    private void StopShoot(DeactivateEventArgs args)
	{
		_particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
		_raycastEnabled = false;
		_audioSrc.Stop();
	}

	private void RaycastCheck()
	{
		RaycastHit hit;
		bool hasHit = Physics.Raycast(_shootSource.position, _shootSource.forward, out hit, _distance, _layerMask);

		if (hasHit)
			hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
	}
	#endregion


}
