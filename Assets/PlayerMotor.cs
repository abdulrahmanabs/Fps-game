using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Callbacks;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;
    bool isSprinting = false;
    Transform playerCamera;  // Reference to the camera

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main.transform;  // Assign the camera transform
    }

    public void Move(Vector2 input)
    {
        
        // Get the forward direction of the camera
      
        float horizontal = input.x;
        float vertical = input.y;

        Vector3 localMoveDirection = new Vector3(horizontal,0,vertical);
        Vector3 moveDirection = transform.TransformDirection(localMoveDirection)*moveSpeed;

        rb.velocity=new Vector3(moveDirection.x,0,moveDirection.z)*Time.fixedDeltaTime;
        
        

    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void Sprint()
    {
        if (!IsGrounded()) return;
        isSprinting = !isSprinting;
        moveSpeed = isSprinting ? moveSpeed*1.3f : moveSpeed/1.0f;
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        float rayLength = 1.5f;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength, groundLayer))
        {
            return true;
        }

        return false;
    }
}
