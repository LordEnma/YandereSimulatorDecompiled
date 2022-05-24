using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000551 RID: 1361
	public class HandHeldCam : LookatTarget
	{
		// Token: 0x060022DA RID: 8922 RVA: 0x001F7508 File Offset: 0x001F5708
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

		// Token: 0x04004B84 RID: 19332
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		// Token: 0x04004B85 RID: 19333
		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		// Token: 0x04004B86 RID: 19334
		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		// Token: 0x04004B87 RID: 19335
		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;
	}
}
