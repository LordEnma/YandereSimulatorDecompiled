using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000540 RID: 1344
	[ExecuteInEditMode]
	public class AutoCam : PivotBasedCameraRig
	{
		// Token: 0x06002270 RID: 8816 RVA: 0x001EDCBC File Offset: 0x001EBEBC
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

		// Token: 0x04004A48 RID: 19016
		[SerializeField]
		private float m_MoveSpeed = 3f;

		// Token: 0x04004A49 RID: 19017
		[SerializeField]
		private float m_TurnSpeed = 1f;

		// Token: 0x04004A4A RID: 19018
		[SerializeField]
		private float m_RollSpeed = 0.2f;

		// Token: 0x04004A4B RID: 19019
		[SerializeField]
		private bool m_FollowVelocity;

		// Token: 0x04004A4C RID: 19020
		[SerializeField]
		private bool m_FollowTilt = true;

		// Token: 0x04004A4D RID: 19021
		[SerializeField]
		private float m_SpinTurnLimit = 90f;

		// Token: 0x04004A4E RID: 19022
		[SerializeField]
		private float m_TargetVelocityLowerLimit = 4f;

		// Token: 0x04004A4F RID: 19023
		[SerializeField]
		private float m_SmoothTurnTime = 0.2f;

		// Token: 0x04004A50 RID: 19024
		private float m_LastFlatAngle;

		// Token: 0x04004A51 RID: 19025
		private float m_CurrentTurnAmount;

		// Token: 0x04004A52 RID: 19026
		private float m_TurnSpeedVelocityChange;

		// Token: 0x04004A53 RID: 19027
		private Vector3 m_RollUp = Vector3.up;
	}
}
