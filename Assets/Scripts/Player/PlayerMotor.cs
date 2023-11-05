using System.Runtime.InteropServices.WindowsRuntime;
using JetBrains.Annotations;
using TreeEditor;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;
    const float groundDrag = 5f;

    float playerHeight = 2;
    bool isSprinting = false;


    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float airMultiplier;
    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 input)
    {

        float horizontal = input.x;
        float vertical = input.y;

        Vector3 localMoveDirection = new Vector3(horizontal, 0, vertical);
        Vector3 moveDirection = transform.TransformDirection(localMoveDirection) * moveSpeed;

        if (IsGrounded())
            rb.AddForce(moveDirection * Time.fixedDeltaTime, ForceMode.VelocityChange);
        else
            rb.AddForce(moveDirection * Time.fixedDeltaTime * airMultiplier, ForceMode.Force);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rb.drag = 0;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }

    public void Sprint()
    {
        if (!IsGrounded()) return;
        isSprinting = !isSprinting;
        moveSpeed = isSprinting ? moveSpeed * 1.3f : moveSpeed / 1.3f;
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        float rayLength = 0.2f;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, (playerHeight * 0.5f) + rayLength, groundLayer))
        {
            rb.drag = groundDrag;
            return true;
        }
        else
        {
            rb.drag = 0;
            return false;
        }
    }
}
