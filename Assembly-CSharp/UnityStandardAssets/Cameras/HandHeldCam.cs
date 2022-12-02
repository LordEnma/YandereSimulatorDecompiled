using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	public class HandHeldCam : LookatTarget
	{
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;

		protected override void FollowTarget(float deltaTime)
		{
			base.FollowTarget(deltaTime);
			float num = Mathf.PerlinNoise(0f, Time.time * m_SwaySpeed) - 0.5f;
			float num2 = Mathf.PerlinNoise(0f, Time.time * m_SwaySpeed + 100f) - 0.5f;
			num *= m_BaseSwayAmount;
			num2 *= m_BaseSwayAmount;
			float num3 = Mathf.PerlinNoise(0f, Time.time * m_SwaySpeed) - 0.5f + m_TrackingBias;
			float num4 = Mathf.PerlinNoise(0f, Time.time * m_SwaySpeed + 100f) - 0.5f + m_TrackingBias;
			num3 *= (0f - m_TrackingSwayAmount) * m_FollowVelocity.x;
			num4 *= m_TrackingSwayAmount * m_FollowVelocity.y;
			base.transform.Rotate(num + num3, num2 + num4, 0f);
		}
	}
}
