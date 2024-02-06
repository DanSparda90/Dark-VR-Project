using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Disable/Enable the hand model when that hand grabs or drops an object
/// </summary>
public class DisableHandOnGrabObject : MonoBehaviour
{
    #region Fields
    private GameObject _leftHandModel;
    private GameObject _rightHandModel;
    private XRGrabInteractable _grabInteractable;

    #endregion

    #region Unity Callbacks
    void Start()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        _leftHandModel = XRElementsController.Instance.LeftHand;
        _rightHandModel = XRElementsController.Instance.RightHand;

        _grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        _grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

	private void OnDestroy()
	{
        _grabInteractable.selectEntered.RemoveListener(HideGrabbingHand);
        _grabInteractable.selectExited.RemoveListener(ShowGrabbingHand);
    }
	#endregion

	#region Methods
	private void HideGrabbingHand(SelectEnterEventArgs args)
	{
        if (args.interactorObject.transform.CompareTag("LeftHand"))
            _leftHandModel.SetActive(false);
        else if (args.interactorObject.transform.CompareTag("RightHand"))
            _rightHandModel.SetActive(false);
	}

    private void ShowGrabbingHand(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("LeftHand"))
            _leftHandModel.SetActive(true);
        else if (args.interactorObject.transform.CompareTag("RightHand"))
            _rightHandModel.SetActive(true);
    }
    #endregion

}
