using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052B RID: 1323
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x060021A3 RID: 8611 RVA: 0x001EAA5B File Offset: 0x001E8C5B
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x060021A4 RID: 8612 RVA: 0x001EAA7E File Offset: 0x001E8C7E
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x060021A5 RID: 8613 RVA: 0x001EAA88 File Offset: 0x001E8C88
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

		// Token: 0x060021A6 RID: 8614 RVA: 0x001EAC2A File Offset: 0x001E8E2A
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x040049A5 RID: 18853
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x040049A6 RID: 18854
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x040049A7 RID: 18855
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x040049A8 RID: 18856
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x040049A9 RID: 18857
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x040049AA RID: 18858
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x040049AB RID: 18859
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x040049AC RID: 18860
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x040049AD RID: 18861
		[SerializeField]
		private Transform m_Target;

		// Token: 0x040049AE RID: 18862
		private AeroplaneController m_AeroplaneController;

		// Token: 0x040049AF RID: 18863
		private float m_RandomPerlin;

		// Token: 0x040049B0 RID: 18864
		private bool m_TakenOff;
	}
}
