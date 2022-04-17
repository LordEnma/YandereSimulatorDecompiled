using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000538 RID: 1336
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x060021F9 RID: 8697 RVA: 0x001F19E7 File Offset: 0x001EFBE7
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x001F1A0A File Offset: 0x001EFC0A
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001F1A14 File Offset: 0x001EFC14
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

		// Token: 0x060021FC RID: 8700 RVA: 0x001F1BB6 File Offset: 0x001EFDB6
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x04004A96 RID: 19094
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x04004A97 RID: 19095
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x04004A98 RID: 19096
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x04004A99 RID: 19097
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x04004A9A RID: 19098
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x04004A9B RID: 19099
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x04004A9C RID: 19100
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x04004A9D RID: 19101
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x04004A9E RID: 19102
		[SerializeField]
		private Transform m_Target;

		// Token: 0x04004A9F RID: 19103
		private AeroplaneController m_AeroplaneController;

		// Token: 0x04004AA0 RID: 19104
		private float m_RandomPerlin;

		// Token: 0x04004AA1 RID: 19105
		private bool m_TakenOff;
	}
}
