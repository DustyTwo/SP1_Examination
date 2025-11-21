using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float jumpSpeed;
    
    [SerializeField]
    Transform groundCheckTransform;
    [SerializeField]
    float groundCheckRadius;
    [SerializeField]
    LayerMask groundLayerMask;

    
    private Rigidbody2D myRigidbody;
    private Transform myTransform;
    private Animator myAnimator;
    private AudioSource jumpAudioSource;
    
    int inputDirection = 0;
    
    bool jumpPressed = false;
    bool grounded = false;
    
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();
        
        
        jumpAudioSource = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
        inputDirection = 0;

        if (Input.GetKey(KeyCode.A))
        {
            inputDirection -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputDirection += 1;
        }
        
        if (inputDirection == 1 && (Mathf.Approximately(myTransform.rotation.eulerAngles.y, 180f) || Mathf.Approximately(myTransform.rotation.eulerAngles.y, -180f)))
        {
            myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, 0f, myTransform.rotation.z);
        }
        else if (inputDirection == -1 && Mathf.Approximately(myTransform.rotation.eulerAngles.y, 0f))
        {
            myTransform.rotation = Quaternion.Euler(myTransform.rotation.x, 180f, myTransform.rotation.z);
        }

        jumpPressed = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W);
        
    }

    private void FixedUpdate()
    {
        myRigidbody.linearVelocityX = inputDirection * movementSpeed;
        
        myAnimator.SetFloat("PlayerSpeed", Mathf.Abs(myRigidbody.linearVelocityX));
        
        grounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayerMask);
        
        myAnimator.SetBool("Grounded", grounded);
        
        if (jumpPressed && grounded)
        {
            myRigidbody.linearVelocityY = jumpSpeed;
            //if (!jumpAudioSource.isPlaying)
            //{
            //    jumpAudioSource.Play();
            //}
        }
        
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
        
    }
    
}
