using UnityEngine;

/// <summary>
/// Disables the object that is putted inside using the OnEnterEvent event
/// </summary>
public class TrashCan : MonoBehaviour
{
	#region Fields
	[SerializeField] private ParticleSystem _effectOnDestroyObject;
	private AudioSource _audioSrc;

	#endregion

	#region Unity Callbacks
	private void Start()
	{
		_audioSrc = GetComponent<AudioSource>();
		GetComponent<GenericTrigger>().OnEnterEvent.AddListener(InsideTrash);	
	}
	#endregion

	#region Methods
	public void InsideTrash(GameObject obj)
	{
		obj.SetActive(false);
		_audioSrc.Play();
		_effectOnDestroyObject.Play();
	}

	#endregion
}
