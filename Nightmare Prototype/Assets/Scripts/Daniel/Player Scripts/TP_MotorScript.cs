using UnityEngine;
using System.Collections;

public class TP_MotorScript : MonoBehaviour 
{
    public static TP_MotorScript Instance;

    public float MoveSpeed = 10.0f;

    public Vector3 MoveVector { get; set; }

    void Awake()
    {
        Instance = this;
    }

    public void UpdateMotor()
    {
        SnapAlignCharacterWithCamera();
        
        ProcessMotion();
    }

    void ProcessMotion()
    {
        // Transform MoveVector to Worldspace
        MoveVector = transform.TransformDirection(MoveVector);

        // Normalize MoveVector if Magnitude > 1
        if (MoveVector.magnitude > 1)
            MoveVector = Vector3.Normalize(MoveVector);

        // Multiply MoveVector by MoveSpeed
        MoveVector *= MoveSpeed;

        // Multiply MoveVector by DeltaTime
        MoveVector *= Time.deltaTime;

        // Move the Character in the Worldspace
        TP_ControllerScript.player_Character_Controller.Move(MoveVector);
    }

    void SnapAlignCharacterWithCamera()
    {
        if (MoveVector.x != 0 || MoveVector.z != 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x,
                                                  Camera.main.transform.eulerAngles.y,
                                                  transform.eulerAngles.z);
        }
    }
}
