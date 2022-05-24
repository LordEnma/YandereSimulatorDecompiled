using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053A RID: 1338
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x0600220E RID: 8718 RVA: 0x001F4B27 File Offset: 0x001F2D27
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x001F4B4A File Offset: 0x001F2D4A
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x06002210 RID: 8720 RVA: 0x001F4B54 File Offset: 0x001F2D54
		private void FixedUpdate()
		{
			if (this.m_Target != null)
			{
				Vector3 position = this.m_Target.position + base.transform.right * (Mathf.PerlinNoise(Time.time * this.m_LateralWanderSpeed, this.m_RandomPerlin) * 2f - 1f) * this.m_LateralWanderDistance;
				Vector3 vector = base.transform.InverseTransformPoint(position);
				float num = Mathf.Atan2(vector.x, vector.z);
				float num2 = (Mathf.Clamp(-Mathf.Atan2(vector.y, vector.z), -this.m_MaxClimbAngle * 0.017453292f, this.m_MaxClimbAngle * 0.017453292f) - this.m_AeroplaneController.PitchAngle) * this.m_PitchSensitivity;
				float num3 = Mathf.Clamp(num, -this.m_MaxRollAngle * 0.017453292f, this.m_MaxRollAngle * 0.017453292f);
				float num4 = 0f;
				float num5 = 0f;
				if (!this.m_TakenOff)
				{
					if (this.m_AeroplaneController.Altitude > this.m_TakeoffHeight)
					{
						this.m_TakenOff = true;
					}
				}
				else
				{
					num4 = num;
					num5 = -(this.m_AeroplaneController.RollAngle - num3) * this.m_RollSensitivity;
				}
				float num6 = 1f + this.m_AeroplaneController.ForwardSpeed * this.m_SpeedEffect;
				num5 *= num6;
				num2 *= num6;
				num4 *= num6;
				this.m_AeroplaneController.Move(num5, num2, num4, 0.5f, false);
				return;
			}
			this.m_AeroplaneController.Move(0f, 0f, 0f, 0f, false);
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x001F4CF6 File Offset: 0x001F2EF6
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x04004ADC RID: 19164
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x04004ADD RID: 19165
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x04004ADE RID: 19166
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x04004ADF RID: 19167
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x04004AE0 RID: 19168
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x04004AE1 RID: 19169
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x04004AE2 RID: 19170
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x04004AE3 RID: 19171
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x04004AE4 RID: 19172
		[SerializeField]
		private Transform m_Target;

		// Token: 0x04004AE5 RID: 19173
		private AeroplaneController m_AeroplaneController;

		// Token: 0x04004AE6 RID: 19174
		private float m_RandomPerlin;

		// Token: 0x04004AE7 RID: 19175
		private bool m_TakenOff;
	}
}
