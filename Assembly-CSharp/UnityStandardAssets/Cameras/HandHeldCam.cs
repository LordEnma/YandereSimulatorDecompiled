using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053F RID: 1343
	public class HandHeldCam : LookatTarget
	{
		// Token: 0x0600225F RID: 8799 RVA: 0x001EB7DC File Offset: 0x001E99DC
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

		// Token: 0x04004A29 RID: 18985
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		// Token: 0x04004A2A RID: 18986
		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		// Token: 0x04004A2B RID: 18987
		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		// Token: 0x04004A2C RID: 18988
		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;
	}
}
