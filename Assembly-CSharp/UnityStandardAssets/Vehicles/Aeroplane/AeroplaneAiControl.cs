using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000537 RID: 1335
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x060021EA RID: 8682 RVA: 0x001F0A5B File Offset: 0x001EEC5B
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x001F0A7E File Offset: 0x001EEC7E
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x001F0A88 File Offset: 0x001EEC88
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

		// Token: 0x060021ED RID: 8685 RVA: 0x001F0C2A File Offset: 0x001EEE2A
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x04004A80 RID: 19072
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x04004A81 RID: 19073
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x04004A82 RID: 19074
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x04004A83 RID: 19075
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x04004A84 RID: 19076
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x04004A85 RID: 19077
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x04004A86 RID: 19078
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x04004A87 RID: 19079
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x04004A88 RID: 19080
		[SerializeField]
		private Transform m_Target;

		// Token: 0x04004A89 RID: 19081
		private AeroplaneController m_AeroplaneController;

		// Token: 0x04004A8A RID: 19082
		private float m_RandomPerlin;

		// Token: 0x04004A8B RID: 19083
		private bool m_TakenOff;
	}
}
