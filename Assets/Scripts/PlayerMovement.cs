using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerMovement : MonoBehaviour
{
    //Running and movement
    public float movementSpeed;

    public Rigidbody2D rb;
    public Animator anim;

    //Jumping
    public float jumpForce;
    public Transform feet;
    public LayerMask groundLayers;
    public bool IsGrounded;

    //Sliding
    public bool isSliding;

    // Actual varible holding value of input
    public float mx;

    //Checking if player is looking left or right
    public bool islookingLeft;

    //Post Proccessing Toggle
    [SerializeField] private PostProcessVolume _postProcessVolume;
    private ChromaticAberration _chromaticAberration;

    //Sounds
    public AudioManager audioManager;
    bool RunningsoundPlaying = false;
    bool JumpingsoundPlaying = false;
    bool SlidingsoundPlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        islookingLeft = true;
        _postProcessVolume.profile.TryGetSettings(out _chromaticAberration);
    }

    // Update is called once per frame
    void Update()
    {
        //Running sound
        if (!IsGrounded || mx == 0f || isSliding == true)
        {
            audioManager.Stop("Walking");
            RunningsoundPlaying = false;
        }
        else if (!RunningsoundPlaying)
        {
            audioManager.Play("Walking");
            RunningsoundPlaying = true;
        }

        //Jumping sound
        if (IsGrounded == true || isSliding == true)
        {
            audioManager.Stop("Jumping");
            JumpingsoundPlaying = false;
        }
        else if (!JumpingsoundPlaying)
        {
            audioManager.Play("Jumping");
            JumpingsoundPlaying = true;
        }

        //Sliding sound
        if (isSliding == false)
        {
            audioManager.Stop("Sliding");
            SlidingsoundPlaying = false;
        }
        else if (isSliding == true && !SlidingsoundPlaying)
        {
            audioManager.Play("Sliding");
            SlidingsoundPlaying = true;
        }




        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded == true)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded == true)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.S)) // While S is pressed down slide
        {
            isSliding = true;

            _chromaticAberration.active = true;
            movementSpeed = 35f;
            Vector2 Slidingmovement = new Vector2(mx * movementSpeed, rb.velocity.y);
            rb.velocity = Slidingmovement;
        }

        if (Input.GetKey(KeyCode.S) == false) // When S is not pressed down dont slide
        {
            _chromaticAberration.active = false;
            isSliding = false;
            movementSpeed = 25f;
        }

        if (Input.GetKey(KeyCode.S) == true && Input.GetButtonDown("Jump") == true || Input.GetKeyDown(KeyCode.W) == true && IsGrounded == true) //Go from Slide to jump instantly
        {
            isSliding = false;
            Jump();
            Debug.Log("From sliding to jump");
        }

        //Jumping Code
        //Checking if character can jump
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            IsGrounded = true;
        }
        else if (groundCheck == null)
        {
            IsGrounded = false;
        }

        //Running Animation
        if (Mathf.Abs(mx) > 0.05f)
        {
            anim.SetBool("isRunning", true);
           
        }
        else
        {
            anim.SetBool("isRunning", false);

        }

        //Jumping Animation logic
        anim.SetBool("isGrounded", IsGrounded == true);

        //Sliding animation logic
        anim.SetBool("isSliding", (isSliding));


        // Flips Player to direction moving in
        if (mx > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            islookingLeft = true;

        }
        else if (mx < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            islookingLeft = false;
        }
    }

    private void FixedUpdate()
    {
        //Running
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump()
    {
        //Jumping
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = movement;

        IsGrounded = false;
    }

    private void OnDrawGizmos() //Debugging ground check 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(feet.position, 0.5f);
    }
}

//Slow motion on sliding into enemy if I ever need it
/*
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Elf" && isSliding == true)
    {
        timeManager.DoSlowmotion();
        Invoke("StopSlowMotion", 1f);
    }
}

public void StopSlowMotion()
{
    timeManager.StopSlowmotion();
}
*/
