using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 12f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 10f;
    [SerializeField] GameObject[] guns;

    [Header("Screen Limits")]
    [SerializeField] float xMin = -5.0f;
    [SerializeField] float xMax = 5.0f;
    [SerializeField] float yMin = -3.75f;
    [SerializeField] float yMax = 3.75f;

    [Header("Ship Rotation")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -15f;

    float xThrow, yThrow;
    bool isAlive = true;
    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            VerticalMovement();
            HorizontalMovement();
            ShipRotation();
            ProcessFiring();
        }
        
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    public void Deactivate() // Called by string reference
    {
        print("Controls frozen");
        isAlive = false;
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
