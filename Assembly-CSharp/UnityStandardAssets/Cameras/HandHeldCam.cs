using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054F RID: 1359
	public class HandHeldCam : LookatTarget
	{
		// Token: 0x060022C5 RID: 8901 RVA: 0x001F43C8 File Offset: 0x001F25C8
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

		// Token: 0x04004B3E RID: 19262
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		// Token: 0x04004B3F RID: 19263
		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		// Token: 0x04004B40 RID: 19264
		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		// Token: 0x04004B41 RID: 19265
		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;
	}
}
