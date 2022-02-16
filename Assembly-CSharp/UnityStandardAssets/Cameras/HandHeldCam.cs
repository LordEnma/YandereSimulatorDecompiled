using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000543 RID: 1347
	public class HandHeldCam : LookatTarget
	{
		// Token: 0x0600227F RID: 8831 RVA: 0x001EE6AC File Offset: 0x001EC8AC
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

		// Token: 0x04004A6A RID: 19050
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		// Token: 0x04004A6B RID: 19051
		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		// Token: 0x04004A6C RID: 19052
		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		// Token: 0x04004A6D RID: 19053
		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;
	}
}
