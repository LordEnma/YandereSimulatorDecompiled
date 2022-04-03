using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054C RID: 1356
	[ExecuteInEditMode]
	public class AutoCam : PivotBasedCameraRig
	{
		// Token: 0x060022AE RID: 8878 RVA: 0x001F2F00 File Offset: 0x001F1100
		protected override void FollowTarget(float deltaTime)
		{
			if (deltaTime <= 0f || this.m_Target == null)
			{
				return;
			}
			Vector3 vector = this.m_Target.forward;
			Vector3 up = this.m_Target.up;
			if (this.m_FollowVelocity && Application.isPlaying)
			{
				if (this.targetRigidbody.velocity.magnitude > this.m_TargetVelocityLowerLimit)
				{
					vector = this.targetRigidbody.velocity.normalized;
					up = Vector3.up;
				}
				else
				{
					up = Vector3.up;
				}
				this.m_CurrentTurnAmount = Mathf.SmoothDamp(this.m_CurrentTurnAmount, 1f, ref this.m_TurnSpeedVelocityChange, this.m_SmoothTurnTime);
			}
			else
			{
				float num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
				if (this.m_SpinTurnLimit > 0f)
				{
					float value = Mathf.Abs(Mathf.DeltaAngle(this.m_LastFlatAngle, num)) / deltaTime;
					float num2 = Mathf.InverseLerp(this.m_SpinTurnLimit, this.m_SpinTurnLimit * 0.75f, value);
					float smoothTime = (this.m_CurrentTurnAmount > num2) ? 0.1f : 1f;
					if (Application.isPlaying)
					{
						this.m_CurrentTurnAmount = Mathf.SmoothDamp(this.m_CurrentTurnAmount, num2, ref this.m_TurnSpeedVelocityChange, smoothTime);
					}
					else
					{
						this.m_CurrentTurnAmount = num2;
					}
				}
				else
				{
					this.m_CurrentTurnAmount = 1f;
				}
				this.m_LastFlatAngle = num;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
			if (!this.m_FollowTilt)
			{
				vector.y = 0f;
				if (vector.sqrMagnitude < 1E-45f)
				{
					vector = base.transform.forward;
				}
			}
			Quaternion b = Quaternion.LookRotation(vector, this.m_RollUp);
			this.m_RollUp = ((this.m_RollSpeed > 0f) ? Vector3.Slerp(this.m_RollUp, up, this.m_RollSpeed * deltaTime) : Vector3.up);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, this.m_TurnSpeed * this.m_CurrentTurnAmount * deltaTime);
		}

		// Token: 0x04004B0F RID: 19215
		[SerializeField]
		private float m_MoveSpeed = 3f;

		// Token: 0x04004B10 RID: 19216
		[SerializeField]
		private float m_TurnSpeed = 1f;

		// Token: 0x04004B11 RID: 19217
		[SerializeField]
		private float m_RollSpeed = 0.2f;

		// Token: 0x04004B12 RID: 19218
		[SerializeField]
		private bool m_FollowVelocity;

		// Token: 0x04004B13 RID: 19219
		[SerializeField]
		private bool m_FollowTilt = true;

		// Token: 0x04004B14 RID: 19220
		[SerializeField]
		private float m_SpinTurnLimit = 90f;

		// Token: 0x04004B15 RID: 19221
		[SerializeField]
		private float m_TargetVelocityLowerLimit = 4f;

		// Token: 0x04004B16 RID: 19222
		[SerializeField]
		private float m_SmoothTurnTime = 0.2f;

		// Token: 0x04004B17 RID: 19223
		private float m_LastFlatAngle;

		// Token: 0x04004B18 RID: 19224
		private float m_CurrentTurnAmount;

		// Token: 0x04004B19 RID: 19225
		private float m_TurnSpeedVelocityChange;

		// Token: 0x04004B1A RID: 19226
		private Vector3 m_RollUp = Vector3.up;
	}
}
