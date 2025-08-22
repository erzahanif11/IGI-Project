using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Animation")]
    public Animator animator;
    private string moveParameterName = "moveDirection";
    private string isWalkingParameterName = "isWalking";
    public bool forceIdle = false;

    [Header("Movement")]
    public float moveSpeed;
    
    [Header("Dont edit")]
    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isWalking;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (forceIdle)
        {
            isWalking = false;
            animator.SetFloat(moveParameterName, 0);
            animator.SetBool(isWalkingParameterName, false);
            rb.linearVelocity = Vector3.zero;
            return;
        }
        float moveX = moveInput.x;
        Move(moveX);
        FLip(moveX);
        animator.SetFloat(moveParameterName, Mathf.Abs(moveX));
        animator.SetBool(isWalkingParameterName, isWalking);
    }
    
    void Move(float moveX)
    {
        if (Mathf.Abs(moveX) > 0.01f)
        {
            isWalking = true;
            Vector3 move = new Vector3(moveX * moveSpeed, 0, 0);
            rb.linearVelocity = move;
        }
        else
        {
            isWalking = false;
            rb.linearVelocity = Vector3.zero;
        }
    }

    void FLip(float moveX)
    {
        if (moveX > 0.01)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveX < -0.01)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    #region InputSystem
    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }
    #endregion
}
