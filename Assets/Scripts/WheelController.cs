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

    public float maxAcceleration = 500f;
    public float brakingForce = 300f;

    private float wheelAcceleration = 0f;
    private float currentBrakeForce = 0f;
    private float currentTurnAngle = 0f;

    public float maxTurnAngle = 30f;
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

        float throttle = Input.GetAxis("Vertical");
        wheelAcceleration = maxAcceleration * throttle;
        //currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space)) {
            currentBrakeForce = brakingForce;
        }
        else {
            currentBrakeForce = 0f;
        }

        frontRight.motorTorque = wheelAcceleration;
        frontLeft.motorTorque = wheelAcceleration;

        frontRight.brakeTorque = currentBrakeForce;
        frontLeft.brakeTorque = currentBrakeForce;
        backRight.brakeTorque = currentBrakeForce;
        backLeft.brakeTorque = currentBrakeForce;

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;
        
        UpdateWheelVisual(frontRight, frontRightTransform);
        UpdateWheelVisual(frontLeft, frontLeftTransform);
        
        //UpdateWheelVisual(backRight, backRightTransform);
        //UpdateWheelVisual(backLeft, backLeftTransform);
    }

    void UpdateWheelVisual(WheelCollider wheelCollider, Transform targetTransform) {
        Vector3 wheelPosition;
        Quaternion wheelRotation;

        wheelCollider.GetWorldPose(out wheelPosition, out wheelRotation);

        Vector3 newRotation = new Vector3(-wheelRotation.eulerAngles.x, wheelRotation.eulerAngles.y + 180, wheelRotation.eulerAngles.z);

        targetTransform.position = wheelPosition;
        targetTransform.rotation = Quaternion.Euler(newRotation);
    }
}
