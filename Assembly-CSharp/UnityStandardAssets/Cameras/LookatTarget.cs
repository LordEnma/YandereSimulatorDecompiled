using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000550 RID: 1360
	public class LookatTarget : AbstractTargetFollower
	{
		// Token: 0x060022C7 RID: 8903 RVA: 0x001F44E6 File Offset: 0x001F26E6
		protected override void Start()
		{
			base.Start();
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x060022C8 RID: 8904 RVA: 0x001F4500 File Offset: 0x001F2700
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

		// Token: 0x04004B42 RID: 19266
		[SerializeField]
		private Vector2 m_RotationRange;

		// Token: 0x04004B43 RID: 19267
		[SerializeField]
		private float m_FollowSpeed = 1f;

		// Token: 0x04004B44 RID: 19268
		private Vector3 m_FollowAngles;

		// Token: 0x04004B45 RID: 19269
		private Quaternion m_OriginalRotation;

		// Token: 0x04004B46 RID: 19270
		protected Vector3 m_FollowVelocity;
	}
}
