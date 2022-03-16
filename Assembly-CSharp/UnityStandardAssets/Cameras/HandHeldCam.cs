using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000549 RID: 1353
	public class HandHeldCam : LookatTarget
	{
		// Token: 0x060022A6 RID: 8870 RVA: 0x001F1BCC File Offset: 0x001EFDCC
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

		// Token: 0x04004AF6 RID: 19190
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		// Token: 0x04004AF7 RID: 19191
		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		// Token: 0x04004AF8 RID: 19192
		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		// Token: 0x04004AF9 RID: 19193
		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;
	}
}
