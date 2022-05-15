using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054F RID: 1359
	[ExecuteInEditMode]
	public class AutoCam : PivotBasedCameraRig
	{
		// Token: 0x060022D1 RID: 8913 RVA: 0x001F6A64 File Offset: 0x001F4C64
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

		// Token: 0x04004B62 RID: 19298
		[SerializeField]
		private float m_MoveSpeed = 3f;

		// Token: 0x04004B63 RID: 19299
		[SerializeField]
		private float m_TurnSpeed = 1f;

		// Token: 0x04004B64 RID: 19300
		[SerializeField]
		private float m_RollSpeed = 0.2f;

		// Token: 0x04004B65 RID: 19301
		[SerializeField]
		private bool m_FollowVelocity;

		// Token: 0x04004B66 RID: 19302
		[SerializeField]
		private bool m_FollowTilt = true;

		// Token: 0x04004B67 RID: 19303
		[SerializeField]
		private float m_SpinTurnLimit = 90f;

		// Token: 0x04004B68 RID: 19304
		[SerializeField]
		private float m_TargetVelocityLowerLimit = 4f;

		// Token: 0x04004B69 RID: 19305
		[SerializeField]
		private float m_SmoothTurnTime = 0.2f;

		// Token: 0x04004B6A RID: 19306
		private float m_LastFlatAngle;

		// Token: 0x04004B6B RID: 19307
		private float m_CurrentTurnAmount;

		// Token: 0x04004B6C RID: 19308
		private float m_TurnSpeedVelocityChange;

		// Token: 0x04004B6D RID: 19309
		private Vector3 m_RollUp = Vector3.up;
	}
}
