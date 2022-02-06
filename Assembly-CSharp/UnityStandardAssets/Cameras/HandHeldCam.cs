using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000542 RID: 1346
	public class HandHeldCam : LookatTarget
	{
		// Token: 0x06002278 RID: 8824 RVA: 0x001EE1F8 File Offset: 0x001EC3F8
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

		// Token: 0x04004A61 RID: 19041
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		// Token: 0x04004A62 RID: 19042
		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		// Token: 0x04004A63 RID: 19043
		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		// Token: 0x04004A64 RID: 19044
		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;
	}
}
