using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class PlatformerCharacter2D : MonoBehaviour
	{
		[SerializeField]
		private float m_MaxSpeed = 10f;

		[SerializeField]
		private float m_JumpForce = 400f;

		[Range(0f, 1f)]
		[SerializeField]
		private float m_CrouchSpeed = 0.36f;

		[SerializeField]
		private bool m_AirControl;

		[SerializeField]
		private LayerMask m_WhatIsGround;

		private Transform m_GroundCheck;

		private const float k_GroundedRadius = 0.2f;

		private bool m_Grounded;

		private Transform m_CeilingCheck;

		private const float k_CeilingRadius = 0.01f;

		private Animator m_Anim;

		private Rigidbody2D m_Rigidbody2D;

		private bool m_FacingRight = true;

		private void Awake()
		{
			m_GroundCheck = base.transform.Find("GroundCheck");
			m_CeilingCheck = base.transform.Find("CeilingCheck");
			m_Anim = GetComponent<Animator>();
			m_Rigidbody2D = GetComponent<Rigidbody2D>();
		}

		private void FixedUpdate()
		{
			m_Grounded = false;
			Collider2D[] array = Physics2D.OverlapCircleAll(m_GroundCheck.position, 0.2f, m_WhatIsGround);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].gameObject != base.gameObject)
				{
					m_Grounded = true;
				}
			}
			m_Anim.SetBool("Ground", m_Grounded);
			m_Anim.SetFloat("vSpeed", m_Rigidbody2D.linearVelocity.y);
		}

		public void Move(float move, bool crouch, bool jump)
		{
			if (!crouch && m_Anim.GetBool("Crouch") && (bool)Physics2D.OverlapCircle(m_CeilingCheck.position, 0.01f, m_WhatIsGround))
			{
				crouch = true;
			}
			m_Anim.SetBool("Crouch", crouch);
			if (m_Grounded || m_AirControl)
			{
				move = (crouch ? (move * m_CrouchSpeed) : move);
				m_Anim.SetFloat("Speed", Mathf.Abs(move));
				m_Rigidbody2D.linearVelocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.linearVelocity.y);
				if (move > 0f && !m_FacingRight)
				{
					Flip();
				}
				else if (move < 0f && m_FacingRight)
				{
					Flip();
				}
			}
			if (m_Grounded && jump && m_Anim.GetBool("Ground"))
			{
				m_Grounded = false;
				m_Anim.SetBool("Ground", value: false);
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			}
		}

		private void Flip()
		{
			m_FacingRight = !m_FacingRight;
			Vector3 localScale = base.transform.localScale;
			localScale.x *= -1f;
			base.transform.localScale = localScale;
		}
	}
}
