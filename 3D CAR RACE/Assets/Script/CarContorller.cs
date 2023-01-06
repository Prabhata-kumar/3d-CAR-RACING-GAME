using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContorller : MonoBehaviour
{
    private float HorizantalInput;
    private float VerticalInput;
    private bool isBracking;
    private float CurrentSteerAngle;
    private float CurrentBrackForce;

    [SerializeField] private float MoterForce;
    [SerializeField] private float BrackeForce;
    [SerializeField] private float MaxSteerAngle;

    [SerializeField] private WheelCollider FLCollider;
    [SerializeField] private WheelCollider FRCollider;
    [SerializeField] private WheelCollider RLCollider;
    [SerializeField] private WheelCollider RRCollider;

    [SerializeField] private Transform FLTransform;
    [SerializeField] private Transform FRTransform;
    [SerializeField] private Transform RLTransfrom;
    [SerializeField] private Transform RRTransform;

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
        HandalMoters();
        HandalSteering();
        UpdateWheels();
    }

    private void UpdateWheels()
    {
        UpdateSingleWheelMethod(FLCollider, FLTransform);
        UpdateSingleWheelMethod(FRCollider, FRTransform);
        UpdateSingleWheelMethod(RLCollider, RLTransfrom);
        UpdateSingleWheelMethod(RRCollider, RRTransform);
    }

    private void UpdateSingleWheelMethod(WheelCollider Wheelcollider, Transform Wheeltransform)
    {
        Vector3 pos;
        Quaternion rot;
        Wheelcollider.GetWorldPose(out pos, out rot);
        Wheeltransform.rotation = rot;
        Wheeltransform.position = pos;
    }

    private void HandalSteering()
    {
        CurrentSteerAngle = MaxSteerAngle * HorizantalInput;
        FLCollider.steerAngle = CurrentSteerAngle;
        FRCollider.steerAngle = CurrentSteerAngle;
    }

    private void HandalMoters()
    {
        FLCollider.motorTorque = VerticalInput * MoterForce;
        FRCollider.motorTorque = VerticalInput * MoterForce;
        CurrentBrackForce = isBracking ? BrackeForce : 0f;
        AppllyBracking();
    }

    private void AppllyBracking()
    {
        FLCollider.brakeTorque = CurrentBrackForce;
        FRCollider.brakeTorque = CurrentBrackForce;
        RLCollider.brakeTorque = CurrentBrackForce;
        RRCollider.brakeTorque = CurrentBrackForce;
    }

    private void GetInput()
    {
        HorizantalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        isBracking = Input.GetKey(KeyCode.Space);

    }
}
