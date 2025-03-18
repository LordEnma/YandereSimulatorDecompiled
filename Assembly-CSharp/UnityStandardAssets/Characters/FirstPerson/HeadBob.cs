using UnityEngine;
using UnityStandardAssets.Utility;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class HeadBob : MonoBehaviour
	{
		public Camera Camera;

		public CurveControlledBob motionBob = new CurveControlledBob();

		public LerpControlledBob jumpAndLandingBob = new LerpControlledBob();

		public RigidbodyFirstPersonController rigidbodyFirstPersonController;

		public float StrideInterval;

		[Range(0f, 1f)]
		public float RunningStrideLengthen;

		private bool m_PreviouslyGrounded;

		private Vector3 m_OriginalCameraPosition;

		private void Start()
		{
			motionBob.Setup(Camera, StrideInterval);
			m_OriginalCameraPosition = Camera.transform.localPosition;
		}

		private void Update()
		{
			Vector3 localPosition;
			if (rigidbodyFirstPersonController.Velocity.magnitude > 0f && rigidbodyFirstPersonController.Grounded)
			{
				Camera.transform.localPosition = motionBob.DoHeadBob(rigidbodyFirstPersonController.Velocity.magnitude * (rigidbodyFirstPersonController.Running ? RunningStrideLengthen : 1f));
				localPosition = Camera.transform.localPosition;
				localPosition.y = Camera.transform.localPosition.y - jumpAndLandingBob.Offset();
			}
			else
			{
				localPosition = Camera.transform.localPosition;
				localPosition.y = m_OriginalCameraPosition.y - jumpAndLandingBob.Offset();
			}
			Camera.transform.localPosition = localPosition;
			if (!m_PreviouslyGrounded && rigidbodyFirstPersonController.Grounded)
			{
				StartCoroutine(jumpAndLandingBob.DoBobCycle());
			}
			m_PreviouslyGrounded = rigidbodyFirstPersonController.Grounded;
		}
	}
}
