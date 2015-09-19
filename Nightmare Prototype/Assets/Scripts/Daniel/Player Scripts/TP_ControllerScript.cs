﻿using UnityEngine;
using System.Collections;

public class TP_ControllerScript : MonoBehaviour 
{
    public static CharacterController player_Character_Controller;
    public static TP_ControllerScript Instance;

    void Awake()
    {
        player_Character_Controller = GetComponent<CharacterController>();
        Instance = this;

        // Now setup the player/main camera 
        TP_CameraScript.UseExistingOrCreateNewMainCamera();
    }

	void Update() 
    {
        // See if we have our main camera present
        if (Camera.main == null)
            return;

        // Get the players input, horizontal (left/right) || vertical (up/down)
        GetLocomotionInput();

        // Then move the player
        TP_MotorScript.Instance.UpdateMotor();
	}

    void GetLocomotionInput()
    {
        float deadZone = 0.1f;

        TP_MotorScript.Instance.MoveVector = Vector3.zero;

        if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone)
            TP_MotorScript.Instance.MoveVector += new Vector3(0, 0, Input.GetAxis("Vertical"));

        if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
            TP_MotorScript.Instance.MoveVector += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
    }
}
