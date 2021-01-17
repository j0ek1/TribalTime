using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D pRigidbody; //Declaring player rigidbody variable
	private float jumpForce = 500f; //Amount of force exerted when jumping
	private float moveSmooth = .05f; //Amount of movement smoothing applied
	private Vector3 pVelocity = new Vector3(0, 0, 0); //Declaring player velocity variable

	public Transform groundCheck; //A point to determine whether the player is grounded
	private float groundedRadius = .2f; //The radius of the overlap circle to determine if grounded
	private bool grounded; //Whether the player is grounded or not

	public Transform wallCheck;
	private float walledRadius = .2f;
	private bool walled;

	private bool doubleJump = true; //For determining whether they have used their double jump yet
	private float doubleJumpTimer = 0f;
	private bool canDoubleJump = false; //For adding a delay between normal and double jump

	private bool facingRight = true; //Whether the player is facing right or not

	public Animator pAnimator;

	private void Awake()
	{
		pRigidbody = GetComponent<Rigidbody2D>(); //Assigning players rigidbody to the variable
	}

	private void Update()
	{
		if (!walled || !grounded) //Implementing small timer so player cannot walljump and double jump at the same time
		{
			doubleJumpTimer -= Time.deltaTime;
		}
		if (doubleJumpTimer < 0)
		{
			canDoubleJump = true;
		}
		else
		{
			canDoubleJump = false;
		}
		pAnimator.SetFloat("yVelocity", pRigidbody.velocity.y);
	}

	private void FixedUpdate()
	{
		bool wasGrounded = grounded;
		grounded = false;
		walled = false;
		Collider2D[] gColliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius); //Create circle collider to check if player is touching ground by overlapping colliders
		Collider2D[] wColliders = Physics2D.OverlapCircleAll(wallCheck.position, walledRadius);
		for (int i = 0; i < gColliders.Length; i++)
		{
			if (gColliders[i].gameObject != gameObject) //If the ground collider is not overlapped with the player, then grounded is true
			{
				grounded = true;
				doubleJump = true;
				if (!wasGrounded)
				{
					pAnimator.SetBool("isJumping", false);
				}
			}
		}
		for (int i = 0; i < wColliders.Length; i++)
		{
			if (wColliders[i].gameObject != gameObject) //If the wall collider is not overlapped with the player, then walled is true
			{
				walled = true;
				doubleJump = true;
			}
		}
	}

	public void Move(float move, bool jump)
	{
		Vector3 targetVelocity = new Vector2(move, pRigidbody.velocity.y); //Finding the target velocity
		pRigidbody.velocity = Vector3.SmoothDamp(pRigidbody.velocity, targetVelocity, ref pVelocity, moveSmooth); //Moving the player up to the target velocity with smoothing

		if (move > 0 && !facingRight) //If the movement direction is to the right and player is facing left
		{
			Flip();
		}
		else if (move < 0 && facingRight) //Else if movement is left and player is facing right
		{
			Flip();
		}
		if (doubleJump && jump && !grounded && canDoubleJump) //If the player wants to double jump
		{
			if (walled && move != 0) //If player is walled and grounded, but wants to walljump, don't do anything (let player walljump)
			{

			}
			else //Else, normal double jump
			{
				doubleJump = false;
				pAnimator.SetBool("isDoubleJ", true);
				Invoke("DoubleJumpAnim", 0.3f);
				pRigidbody.velocity = new Vector2(move / 2, 10f);
			}
		}
		if (walled && jump && !grounded && move != 0) //If the player wants to wall jump
		{
			pAnimator.SetBool("isDoubleJ", false);
			walled = false;
			doubleJumpTimer = 0.1f;
			pRigidbody.velocity = new Vector2(-move, 10f);
		}
		if (grounded && jump) //If the player wants to jump and is grounded
		{
			grounded = false;
			doubleJumpTimer = 0.1f;
			pRigidbody.AddForce(new Vector2(0f, jumpForce)); //Adds vertical force to player of specified jump force
		}
	}

	private void Flip() //Function that is called when the player changes direction
	{
		facingRight = !facingRight; //Changes the boolean variable to be showing correct updated direction

		Vector3 pScale = transform.localScale; //Grabs players scale
		pScale.x *= -1; //Multiplies players x scale by -1
		transform.localScale = pScale; //Updates players local scale
	}

	private void DoubleJumpAnim()
	{
		pAnimator.SetBool("isDoubleJ", false);
	}
}