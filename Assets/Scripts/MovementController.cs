using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform cameraPointTransform;
    private Rigidbody rb;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float moveAcceleration = 1f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    private void Update()
    {
        if(rb.velocity.magnitude < moveSpeed)
        {
            Vector3 movementVector = cameraPointTransform.forward;
            movementVector.y = 0;
            movementVector.Normalize();
            rb.AddForce(movementVector * moveAcceleration);
        }
    }
}
