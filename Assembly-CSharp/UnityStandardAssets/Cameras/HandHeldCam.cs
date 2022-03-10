using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000545 RID: 1349
	public class HandHeldCam : LookatTarget
	{
		// Token: 0x0600228E RID: 8846 RVA: 0x001EFC64 File Offset: 0x001EDE64
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

		// Token: 0x04004A97 RID: 19095
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		// Token: 0x04004A98 RID: 19096
		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		// Token: 0x04004A99 RID: 19097
		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		// Token: 0x04004A9A RID: 19098
		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;
	}
}
