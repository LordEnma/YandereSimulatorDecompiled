using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000550 RID: 1360
	public class HandHeldCam : LookatTarget
	{
		// Token: 0x060022CE RID: 8910 RVA: 0x001F5854 File Offset: 0x001F3A54
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

		// Token: 0x04004B54 RID: 19284
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		// Token: 0x04004B55 RID: 19285
		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		// Token: 0x04004B56 RID: 19286
		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		// Token: 0x04004B57 RID: 19287
		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;
	}
}
