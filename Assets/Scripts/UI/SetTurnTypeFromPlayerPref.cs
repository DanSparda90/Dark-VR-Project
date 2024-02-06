using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetTurnTypeFromPlayerPref : MonoBehaviour
{
    [SerializeField] private ActionBasedSnapTurnProvider _snapTurn;
    [SerializeField] private ActionBasedContinuousTurnProvider _continuousTurn;

    void Start()
    {
        ApplyPlayerPref();
    }

    public void ApplyPlayerPref()
    {
        if(PlayerPrefs.HasKey("turn"))
        {
            int value = PlayerPrefs.GetInt("turn");
            if(value == 0)
            {
                _snapTurn.rightHandSnapTurnAction.action.Enable();
                _continuousTurn.rightHandTurnAction.action.Disable();
            }
            else if(value == 1)
            {
                _snapTurn.rightHandSnapTurnAction.action.Disable();
                _continuousTurn.rightHandTurnAction.action.Enable();
            }
        }
    }
}
