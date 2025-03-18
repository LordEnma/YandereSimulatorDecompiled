using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof(PlatformerCharacter2D))]
	public class Platformer2DUserControl : MonoBehaviour
	{
		private PlatformerCharacter2D m_Character;

		private bool m_Jump;

		private void Awake()
		{
			m_Character = GetComponent<PlatformerCharacter2D>();
		}

		private void Update()
		{
			if (!m_Jump)
			{
				m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
			}
		}

		private void FixedUpdate()
		{
			bool key = Input.GetKey(KeyCode.LeftControl);
			float axis = CrossPlatformInputManager.GetAxis("Horizontal");
			m_Character.Move(axis, key, m_Jump);
			m_Jump = false;
		}
	}
}
