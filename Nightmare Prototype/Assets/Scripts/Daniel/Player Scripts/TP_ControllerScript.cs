using UnityEngine;
using System.Collections;

public class TP_ControllerScript : MonoBehaviour {

    public static CharacterController player_Character_Controller;
    public static TP_ControllerScript Instance;

    void Awake()
    {
        player_Character_Controller = GetComponent<CharacterController>();

        Instance = this;
    }

	void Update() 
    {
        if (Camera.main == null)
            return;

        GetLocomotionInput();
	}

    void GetLocomotionInput()
    {
        //
    }
}
