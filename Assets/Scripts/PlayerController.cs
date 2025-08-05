using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Animation")]
    public Animator animator;
    private string moveParameterName = "moveDirection";

    [Header("Movement")]
    public float moveSpeed;
    
    [Header("Dont edit")]
    private Rigidbody rb;
    private Vector2 moveInput;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = moveInput.x;
        animator.SetFloat(moveParameterName, Mathf.Abs(moveX));
        Move(moveX);
        FLip(moveX);
    }
    
    void Move(float moveX)
    {
        Vector3 move = new Vector3(moveX * moveSpeed, 0, 0);
        rb.linearVelocity = move;
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
