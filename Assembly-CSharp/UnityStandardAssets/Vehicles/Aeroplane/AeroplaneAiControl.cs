using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000532 RID: 1330
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x060021DA RID: 8666 RVA: 0x001EF1EB File Offset: 0x001ED3EB
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x060021DB RID: 8667 RVA: 0x001EF20E File Offset: 0x001ED40E
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x001EF218 File Offset: 0x001ED418
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

		// Token: 0x060021DD RID: 8669 RVA: 0x001EF3BA File Offset: 0x001ED5BA
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x04004A4E RID: 19022
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x04004A4F RID: 19023
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x04004A50 RID: 19024
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x04004A51 RID: 19025
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x04004A52 RID: 19026
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x04004A53 RID: 19027
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x04004A54 RID: 19028
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x04004A55 RID: 19029
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x04004A56 RID: 19030
		[SerializeField]
		private Transform m_Target;

		// Token: 0x04004A57 RID: 19031
		private AeroplaneController m_AeroplaneController;

		// Token: 0x04004A58 RID: 19032
		private float m_RandomPerlin;

		// Token: 0x04004A59 RID: 19033
		private bool m_TakenOff;
	}
}
