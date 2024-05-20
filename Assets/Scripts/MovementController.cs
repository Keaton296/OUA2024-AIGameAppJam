using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform cameraPointTransform;
    [SerializeField] Animator armsAnimator;  
    private Rigidbody rb;
    [SerializeField] float moveMaxSpeed = 1f;
    [SerializeField] float moveAcceleration = 1f;
    [SerializeField] float runAcceleration = 1f;
    [SerializeField] float runMaxSpeed = 1f;
    [SerializeField] bool isRunning;
    [SerializeField] float stamina;
    [SerializeField] float maxStamina = 100;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    private void Update()
    {
        Vector3 movementVectorZ = cameraPointTransform.forward;
        movementVectorZ.y = 0;
        movementVectorZ.Normalize();
        Vector3 movementVectorX = cameraPointTransform.right;
        movementVectorX.y = 0;
        movementVectorX.Normalize();
        Vector3 movementVector = movementVectorZ * Input.GetAxisRaw("Vertical") + movementVectorX * Input.GetAxisRaw("Horizontal");
        movementVector.Normalize();
        isRunning = Input.GetKey(KeyCode.LeftShift);
        if (rb.velocity.magnitude < moveMaxSpeed && !isRunning)
        {
            rb.AddForce(movementVector * moveAcceleration);
            armsAnimator.SetBool("IsRunning", false);
        }
        else if(rb.velocity.magnitude < runMaxSpeed && isRunning)
        {
            rb.AddForce(movementVector * (moveAcceleration + runAcceleration));
            armsAnimator.SetBool("IsRunning", true);
        }
    }
}
