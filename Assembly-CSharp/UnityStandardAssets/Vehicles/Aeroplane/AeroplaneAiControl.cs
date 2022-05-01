using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000539 RID: 1337
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x06002202 RID: 8706 RVA: 0x001F2E73 File Offset: 0x001F1073
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x001F2E96 File Offset: 0x001F1096
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x001F2EA0 File Offset: 0x001F10A0
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

		// Token: 0x06002205 RID: 8709 RVA: 0x001F3042 File Offset: 0x001F1242
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x04004AAC RID: 19116
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x04004AAD RID: 19117
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x04004AAE RID: 19118
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x04004AAF RID: 19119
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x04004AB0 RID: 19120
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x04004AB1 RID: 19121
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x04004AB2 RID: 19122
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x04004AB3 RID: 19123
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x04004AB4 RID: 19124
		[SerializeField]
		private Transform m_Target;

		// Token: 0x04004AB5 RID: 19125
		private AeroplaneController m_AeroplaneController;

		// Token: 0x04004AB6 RID: 19126
		private float m_RandomPerlin;

		// Token: 0x04004AB7 RID: 19127
		private bool m_TakenOff;
	}
}
