using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform cameraPointTransform;
    private Rigidbody rb;
    [SerializeField] float moveMaxSpeed = 1f;
    [SerializeField] float moveAcceleration = 1f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    private void Update()
    {
        if(rb.velocity.magnitude < moveMaxSpeed)
        {
            Vector3 movementVectorZ = cameraPointTransform.forward;
            movementVectorZ.y = 0;
            movementVectorZ.Normalize();
            Vector3 movementVectorX = cameraPointTransform.right;
            movementVectorX.y = 0;
            movementVectorX.Normalize();
            Vector3 movementVector = movementVectorZ * Input.GetAxisRaw("Vertical") + movementVectorX * Input.GetAxisRaw("Horizontal");
            movementVector.Normalize();
            rb.AddForce(movementVector * moveAcceleration);
        }
    }
}
