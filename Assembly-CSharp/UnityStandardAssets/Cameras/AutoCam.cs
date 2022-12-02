using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	[ExecuteInEditMode]
	public class AutoCam : PivotBasedCameraRig
	{
		[SerializeField]
		private float m_MoveSpeed = 3f;

		[SerializeField]
		private float m_TurnSpeed = 1f;

		[SerializeField]
		private float m_RollSpeed = 0.2f;

		[SerializeField]
		private bool m_FollowVelocity;

		[SerializeField]
		private bool m_FollowTilt = true;

		[SerializeField]
		private float m_SpinTurnLimit = 90f;

		[SerializeField]
		private float m_TargetVelocityLowerLimit = 4f;

		[SerializeField]
		private float m_SmoothTurnTime = 0.2f;

		private float m_LastFlatAngle;

		private float m_CurrentTurnAmount;

		private float m_TurnSpeedVelocityChange;

		private Vector3 m_RollUp = Vector3.up;

		protected override void FollowTarget(float deltaTime)
		{
			if (!(deltaTime > 0f) || m_Target == null)
			{
				return;
			}
			Vector3 forward = m_Target.forward;
			Vector3 up = m_Target.up;
			if (m_FollowVelocity && Application.isPlaying)
			{
				if (targetRigidbody.velocity.magnitude > m_TargetVelocityLowerLimit)
				{
					forward = targetRigidbody.velocity.normalized;
					up = Vector3.up;
				}
				else
				{
					up = Vector3.up;
				}
				m_CurrentTurnAmount = Mathf.SmoothDamp(m_CurrentTurnAmount, 1f, ref m_TurnSpeedVelocityChange, m_SmoothTurnTime);
			}
			else
			{
				float num = Mathf.Atan2(forward.x, forward.z) * 57.29578f;
				if (m_SpinTurnLimit > 0f)
				{
					float value = Mathf.Abs(Mathf.DeltaAngle(m_LastFlatAngle, num)) / deltaTime;
					float num2 = Mathf.InverseLerp(m_SpinTurnLimit, m_SpinTurnLimit * 0.75f, value);
					float smoothTime = ((m_CurrentTurnAmount > num2) ? 0.1f : 1f);
					if (Application.isPlaying)
					{
						m_CurrentTurnAmount = Mathf.SmoothDamp(m_CurrentTurnAmount, num2, ref m_TurnSpeedVelocityChange, smoothTime);
					}
					else
					{
						m_CurrentTurnAmount = num2;
					}
				}
				else
				{
					m_CurrentTurnAmount = 1f;
				}
				m_LastFlatAngle = num;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, m_Target.position, deltaTime * m_MoveSpeed);
			if (!m_FollowTilt)
			{
				forward.y = 0f;
				if (forward.sqrMagnitude < float.Epsilon)
				{
					forward = base.transform.forward;
				}
			}
			Quaternion b = Quaternion.LookRotation(forward, m_RollUp);
			m_RollUp = ((m_RollSpeed > 0f) ? Vector3.Slerp(m_RollUp, up, m_RollSpeed * deltaTime) : Vector3.up);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, m_TurnSpeed * m_CurrentTurnAmount * deltaTime);
		}
	}
}
