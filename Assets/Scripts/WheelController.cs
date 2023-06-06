using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WheelController : MonoBehaviour
{
    private InputDevice targetDevice;

    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration = 500f;
    public float brakingForce = 300f;
    public float maxTurnAngle = 65f;

    private float currentAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;

    private float maxAngle = 540f;
    public void SteeringAngleChanged(float val) {
       
        currentTurnAngle = val / maxAngle * maxTurnAngle;
    }

    void Start() {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        targetDevice = devices[0];
    }

    private void FixedUpdate() {

        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        //print(steeringWheel.rotation.x);

        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        //currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space)) {
            currentBrakeForce = brakingForce;
        }
        else {
            currentBrakeForce = 0f;
        }

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBrakeForce;
        frontLeft.brakeTorque = currentBrakeForce;
        backRight.brakeTorque = currentBrakeForce;
        backLeft.brakeTorque = currentBrakeForce;

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        
        //UpdateWheel(backRight, backRightTransform);
        //UpdateWheel(backLeft, backLeftTransform);
    }

    private void UpdateWheel(WheelCollider col, Transform trans) {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = Quaternion.Euler(new Vector3(-rotation.eulerAngles.x, rotation.eulerAngles.y + 180, rotation.eulerAngles.z));
    }
}
