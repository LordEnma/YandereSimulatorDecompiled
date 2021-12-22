using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000528 RID: 1320
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x06002193 RID: 8595 RVA: 0x001E8DFB File Offset: 0x001E6FFB
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x06002194 RID: 8596 RVA: 0x001E8E1E File Offset: 0x001E701E
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x06002195 RID: 8597 RVA: 0x001E8E28 File Offset: 0x001E7028
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

		// Token: 0x06002196 RID: 8598 RVA: 0x001E8FCA File Offset: 0x001E71CA
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x04004981 RID: 18817
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x04004982 RID: 18818
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x04004983 RID: 18819
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x04004984 RID: 18820
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x04004985 RID: 18821
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x04004986 RID: 18822
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x04004987 RID: 18823
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x04004988 RID: 18824
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x04004989 RID: 18825
		[SerializeField]
		private Transform m_Target;

		// Token: 0x0400498A RID: 18826
		private AeroplaneController m_AeroplaneController;

		// Token: 0x0400498B RID: 18827
		private float m_RandomPerlin;

		// Token: 0x0400498C RID: 18828
		private bool m_TakenOff;
	}
}
