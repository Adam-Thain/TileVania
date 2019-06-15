using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; 

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(0f,5f);

    // State
    bool isAlive = true;

    // Cached Component References
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // If The Player is Dead
        if (!isAlive) { return; }

        Run();
        ClimbLadder();
        Jump();
        FlipSprite();
        Die();
    }

    /// <summary>
    /// Move Character
    /// </summary>
    private void Run()
    {
        // Get the axis
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        // Create player velocity with a X set by control throw by runspeed and Y as current velocity
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);

        // Set rigidbody velocity to player velocity
        myRigidBody.velocity = playerVelocity;

        //
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        //
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    //
    private void ClimbLadder()
    {
        //
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("Climbing",false);
            myRigidBody.gravityScale = gravityScaleAtStart;
            return;
        }

        //
        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");

        //
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);

        //
        myRigidBody.velocity = climbVelocity;

        //
        myRigidBody.gravityScale = 0f;

        //
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;

        //
        myAnimator.SetBool("Climbing",playerHasVerticalSpeed);
    }

    /// <summary>
    /// 
    /// </summary>
    private void Jump()
    {
        //
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;}

        //
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            //
            Vector2 JumpVelocityToAdd = new Vector2(0f, jumpSpeed);

            //
            myRigidBody.velocity += JumpVelocityToAdd;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = deathKick;
        }
    }

    /// <summary>
    /// Flip Character Sprite when turning around
    /// </summary>
    private void FlipSprite()
    {
        //
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        //
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
}
