using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053F RID: 1343
	public class HandHeldCam : LookatTarget
	{
		// Token: 0x06002262 RID: 8802 RVA: 0x001EBDCC File Offset: 0x001E9FCC
		protected override void FollowTarget(float deltaTime)
		{
			base.FollowTarget(deltaTime);
			float num = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed) - 0.5f;
			float num2 = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed + 100f) - 0.5f;
			num *= this.m_BaseSwayAmount;
			num2 *= this.m_BaseSwayAmount;
			float num3 = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed) - 0.5f + this.m_TrackingBias;
			float num4 = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed + 100f) - 0.5f + this.m_TrackingBias;
			num3 *= -this.m_TrackingSwayAmount * this.m_FollowVelocity.x;
			num4 *= this.m_TrackingSwayAmount * this.m_FollowVelocity.y;
			base.transform.Rotate(num + num3, num2 + num4, 0f);
		}

		// Token: 0x04004A32 RID: 18994
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		// Token: 0x04004A33 RID: 18995
		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		// Token: 0x04004A34 RID: 18996
		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		// Token: 0x04004A35 RID: 18997
		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;
	}
}
