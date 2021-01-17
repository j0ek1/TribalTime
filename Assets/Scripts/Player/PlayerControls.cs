using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    public PlayerMovement player; //Allows access to call the other scripts functions
    private float horizontalMove = 0f; //Float to obtain the horizontal axis input
    private bool jump = false; //Boolean determins if the player wants to jump or not
    private float runSpeed = 300f;
    public float playerX;

    public Animator pAnimator;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //Update the input on horizontal axis (-1 -> 1) multiplied by runspeed
        playerX = transform.position.x;
        pAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")) //If jump key is pressed, set jump to true
        {
            jump = true;
            pAnimator.SetBool("isJumping", true);
        }
    }

    void FixedUpdate()
    {
        player.Move(horizontalMove * Time.fixedDeltaTime, jump); //Constantly runs move function, will keep key presses in a fixed update
        jump = false; //If the player chose to jump, the boolean gets set back to false
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spike") //If player collides with trigger with tag spike
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}