using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof (HeroCharacter2D))]
public class HeroUserControl : MonoBehaviour
{
    private HeroCharacter2D m_Character;
    private bool m_Jump;


    private void Awake()
    {
        m_Character = GetComponent<HeroCharacter2D>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
    	m_Character.Move(h, m_Jump);
        m_Jump = false;
    }
}
