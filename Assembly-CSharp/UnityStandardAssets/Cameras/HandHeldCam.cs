using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054E RID: 1358
	public class HandHeldCam : LookatTarget
	{
		// Token: 0x060022B6 RID: 8886 RVA: 0x001F343C File Offset: 0x001F163C
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

		// Token: 0x04004B28 RID: 19240
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		// Token: 0x04004B29 RID: 19241
		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		// Token: 0x04004B2A RID: 19242
		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		// Token: 0x04004B2B RID: 19243
		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;
	}
}
