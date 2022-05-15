using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053A RID: 1338
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x0600220D RID: 8717 RVA: 0x001F45BF File Offset: 0x001F27BF
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x0600220E RID: 8718 RVA: 0x001F45E2 File Offset: 0x001F27E2
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x001F45EC File Offset: 0x001F27EC
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

		// Token: 0x06002210 RID: 8720 RVA: 0x001F478E File Offset: 0x001F298E
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x04004AD3 RID: 19155
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x04004AD4 RID: 19156
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x04004AD5 RID: 19157
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x04004AD6 RID: 19158
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x04004AD7 RID: 19159
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x04004AD8 RID: 19160
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x04004AD9 RID: 19161
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x04004ADA RID: 19162
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x04004ADB RID: 19163
		[SerializeField]
		private Transform m_Target;

		// Token: 0x04004ADC RID: 19164
		private AeroplaneController m_AeroplaneController;

		// Token: 0x04004ADD RID: 19165
		private float m_RandomPerlin;

		// Token: 0x04004ADE RID: 19166
		private bool m_TakenOff;
	}
}
