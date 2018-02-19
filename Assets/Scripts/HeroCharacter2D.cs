using System;
using UnityEngine;

public class HeroCharacter2D : MonoBehaviour
{
    [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
	[SerializeField] private float m_AngrySpeedBonus = 10f; 
    [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
    [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
	
    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    //private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private PlayerStats player;
	private GameObject model;
    private Animator m_Anim;            // Reference to the player's animator component.

    private void Awake()
    {
		player = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PlayerStats>();
		
        //m_CeilingCheck = transform.Find("CeilingCheck");
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

	private void Start() {
		PlayerTransformed ();
	}


    private void FixedUpdate()
    {
		if (!model.activeInHierarchy) {
			PlayerTransformed();
		}
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != model && !colliders[i].isTrigger){
                m_Grounded = true;
			}
        }
        m_Anim.SetBool("Ground", m_Grounded);

        // Set the vertical animation
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

    }


    public void Move(float move, bool jump)
    {
		float control = player.SelfControl / 100;

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // Reduce the speed if crouching by the crouchSpeed multiplier
            //move = (crouch ? move*m_CrouchSpeed : move);

            // The Speed animator parameter is set to the absolute value of the horizontal input.
			m_Anim.SetFloat("Speed", (control < 0.8 && player.Health < 0) ? 1 : Mathf.Abs(move));

			float speed = move*m_MaxSpeed;
			float maxspeed = m_MaxSpeed;
            // Move the character
			if (control < 0.8 && player.Health < 0){
				speed = m_MaxSpeed + (m_AngrySpeedBonus * (1 - Mathf.Pow (control, 4)));
				speed *= m_FacingRight ? 1 : -1;
				maxspeed = m_MaxSpeed + m_AngrySpeedBonus;
			}

			m_Rigidbody2D.velocity = new Vector2(Mathf.Clamp(speed, -maxspeed, maxspeed), m_Rigidbody2D.velocity.y);
            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
                // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }

        // If the player should jump...
        if (m_Grounded && jump && m_Anim.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Anim.SetBool("Ground", false);
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

	void PlayerTransformed ()
	{
		model = GameObject.FindGameObjectWithTag ("Player");
		m_GroundCheck = model.transform.Find ("GroundCheck");
		m_Anim = model.GetComponent<Animator> ();
	}

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
