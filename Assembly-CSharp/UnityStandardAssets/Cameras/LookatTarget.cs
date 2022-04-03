using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054F RID: 1359
	public class LookatTarget : AbstractTargetFollower
	{
		// Token: 0x060022B8 RID: 8888 RVA: 0x001F355A File Offset: 0x001F175A
		protected override void Start()
		{
			base.Start();
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060022B9 RID: 8889 RVA: 0x001F3574 File Offset: 0x001F1774
		protected override void FollowTarget(float deltaTime)
		{
			base.transform.localRotation = this.m_OriginalRotation;
			Vector3 vector = base.transform.InverseTransformPoint(this.m_Target.position);
			float num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
			num = Mathf.Clamp(num, -this.m_RotationRange.y * 0.5f, this.m_RotationRange.y * 0.5f);
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, num, 0f);
			vector = base.transform.InverseTransformPoint(this.m_Target.position);
			float num2 = Mathf.Atan2(vector.y, vector.z) * 57.29578f;
			num2 = Mathf.Clamp(num2, -this.m_RotationRange.x * 0.5f, this.m_RotationRange.x * 0.5f);
			Vector3 target = new Vector3(this.m_FollowAngles.x + Mathf.DeltaAngle(this.m_FollowAngles.x, num2), this.m_FollowAngles.y + Mathf.DeltaAngle(this.m_FollowAngles.y, num));
			this.m_FollowAngles = Vector3.SmoothDamp(this.m_FollowAngles, target, ref this.m_FollowVelocity, this.m_FollowSpeed);
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(-this.m_FollowAngles.x, this.m_FollowAngles.y, 0f);
		}

		// Token: 0x04004B2C RID: 19244
		[SerializeField]
		private Vector2 m_RotationRange;

		// Token: 0x04004B2D RID: 19245
		[SerializeField]
		private float m_FollowSpeed = 1f;

		// Token: 0x04004B2E RID: 19246
		private Vector3 m_FollowAngles;

		// Token: 0x04004B2F RID: 19247
		private Quaternion m_OriginalRotation;

		// Token: 0x04004B30 RID: 19248
		protected Vector3 m_FollowVelocity;
	}
}
