using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 60f;
    [Tooltip("Meters")][SerializeField] float xMaxPos = 29f;
    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 50f;
    [Tooltip("Meters")][SerializeField] float yMaxPos = 19f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -1.1f;
    [SerializeField] float positionYawFactor = 1.1f;
    
    [Header("Control-throw based")]
    [SerializeField] float throwPitchFactor = -20f;
    [SerializeField] float throwRollFactor = -20f;

   private float xThrow, yThrow;
   private bool controlDisabled = false;
   

   // Update is called once per frame
    void Update()
    {
        if (controlDisabled) return;
        ProcessRotation();
        ProcessTranslation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor; 
        float pitchDueToThrowFactor = yThrow * throwPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToThrowFactor;

        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * throwRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw ,roll );
    }

    void OnPlayerDeath() //Called by string reference
    {
        controlDisabled = true;
    }
    
    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewXpos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXpos, -xMaxPos, xMaxPos);

        yThrow = Input.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewYpos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYpos, -yMaxPos, yMaxPos);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
