using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 12f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 10f;
    [SerializeField] float xMin = -5.0f;
    [SerializeField] float xMax = 5.0f;
    [SerializeField] float yMin = -3.75f;
    [SerializeField] float yMax = 3.75f;
    float xThrow, yThrow;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -15f;

    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -15f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerticalMovement();
        HorizontalMovement();
        ShipRotation();
    }

    private void ShipRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void HorizontalMovement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float newXPos = Mathf.Clamp(rawXPos, xMin, xMax);
        transform.localPosition = new Vector3(newXPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void VerticalMovement()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float newYPos = Mathf.Clamp(rawYPos, yMin, yMax);
        transform.localPosition = new Vector3(transform.localPosition.x, newYPos, transform.localPosition.z);
    }

}
