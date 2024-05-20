using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTilter : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float maxTiltVelocity = 2f;
    [SerializeField] float tiltMaxDegrees = 2f;
    [SerializeField] float tiltingAngularSpeed = .7f;
    [SerializeField] float maxBobbingAnimSpeed;
    Animator headBobbingAnimator;
    private void Awake()
    {
        headBobbingAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 movementDir = rb.velocity;    
        if (movementDir.magnitude > maxTiltVelocity)    
        {
            movementDir.Normalize();    
            movementDir *= maxTiltVelocity;
        }
        float speedRatio = movementDir.magnitude / maxTiltVelocity;
        //Mathf.Clamp(Quaternion.Angle(Quaternion.identity, Quaternion.AngleAxis(tiltMaxDegrees * tiltRatio, Vector3.Cross(Vector3.up, movementDir).normalized)),0,tiltMaxDegrees);
        //transform.rotation = Quaternion.identity;
        Quaternion TiltedRotation = Quaternion.AngleAxis(Mathf.Clamp(tiltMaxDegrees * speedRatio, 0, tiltMaxDegrees * speedRatio - Quaternion.Angle(Quaternion.identity,transform.rotation)), Vector3.Cross(Vector3.up, movementDir).normalized); 
        transform.rotation = Quaternion.Slerp(transform.rotation, TiltedRotation, Time.deltaTime * tiltingAngularSpeed);
        headBobbingAnimator.SetBool("Bobbing", rb.velocity.magnitude > 0.1f);
        
    }
    private void FixedUpdate()
    {
        float maxSpeedRatio = rb.velocity.magnitude / maxTiltVelocity;
        headBobbingAnimator.SetFloat("BobbingSpeed", maxSpeedRatio * maxBobbingAnimSpeed);

    }
}
