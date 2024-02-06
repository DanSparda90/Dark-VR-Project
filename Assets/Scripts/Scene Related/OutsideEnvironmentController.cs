using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class OutsideEnvironmentController : MonoBehaviour
{
    #region Fields
    [SerializeField] private XRLever _lever;
    [SerializeField] private XRKnob _knob;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _sideSpeed;
    [SerializeField] private ParticleSystem _speedEffect;

	#endregion

	#region Unity Callbacks
    void Update()
    {
        float forwardVel = _forwardSpeed * (_lever.value ? 1 : 0);
        float sideVel = _sideSpeed * (_lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, _knob.value);

        Vector3 vel = new Vector3(forwardVel * -1, 0, sideVel);
        transform.position += vel * Time.deltaTime;

        if (forwardVel > 0 && !_speedEffect.gameObject.activeSelf)
            _speedEffect.gameObject.SetActive(true);
        if (forwardVel == 0 && _speedEffect.gameObject.activeSelf)
            _speedEffect.gameObject.SetActive(false);
    }

	#endregion
}
