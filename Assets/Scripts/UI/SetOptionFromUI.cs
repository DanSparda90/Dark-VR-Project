using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetOptionFromUI : MonoBehaviour
{
    [SerializeField] private Scrollbar _volumeSlider;
    [SerializeField] private TMP_Dropdown _turnDropdown;
    [SerializeField] private SetTurnTypeFromPlayerPref _turnTypeFromPlayerPref;

    private void Start()
    {
        _volumeSlider.onValueChanged.AddListener(SetGlobalVolume);
        _turnDropdown.onValueChanged.AddListener(SetTurnPlayerPref);

        if (PlayerPrefs.HasKey("turn"))
            _turnDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("turn"));
    }

    private void SetGlobalVolume(float value)
    {
        AudioListener.volume = value;
    }

    private void SetTurnPlayerPref(int value)
    {
        PlayerPrefs.SetInt("turn", value); 
        _turnTypeFromPlayerPref.ApplyPlayerPref();
    }
}
