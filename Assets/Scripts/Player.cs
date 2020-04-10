using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("Meters")][SerializeField] float xMaxPos = 25f;
    
    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 4f;
    [Tooltip("Meters")][SerializeField] float yMaxPos = 25f;
    
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float throwPitchFactor = -20f;
    [SerializeField] float throwRollFactor = -20f;

   private float xThrow, yThrow;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("player triggered");
    }

    // Update is called once per frame
    void Update()
    {
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
