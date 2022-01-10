using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052A RID: 1322
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x060021A1 RID: 8609 RVA: 0x001E9D8B File Offset: 0x001E7F8B
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x060021A2 RID: 8610 RVA: 0x001E9DAE File Offset: 0x001E7FAE
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x060021A3 RID: 8611 RVA: 0x001E9DB8 File Offset: 0x001E7FB8
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

		// Token: 0x060021A4 RID: 8612 RVA: 0x001E9F5A File Offset: 0x001E815A
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x0400499E RID: 18846
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x0400499F RID: 18847
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x040049A0 RID: 18848
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x040049A1 RID: 18849
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x040049A2 RID: 18850
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x040049A3 RID: 18851
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x040049A4 RID: 18852
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x040049A5 RID: 18853
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x040049A6 RID: 18854
		[SerializeField]
		private Transform m_Target;

		// Token: 0x040049A7 RID: 18855
		private AeroplaneController m_AeroplaneController;

		// Token: 0x040049A8 RID: 18856
		private float m_RandomPerlin;

		// Token: 0x040049A9 RID: 18857
		private bool m_TakenOff;
	}
}
