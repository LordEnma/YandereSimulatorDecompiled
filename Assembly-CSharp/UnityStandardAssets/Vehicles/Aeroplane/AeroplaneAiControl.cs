using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000526 RID: 1318
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x06002182 RID: 8578 RVA: 0x001E76C7 File Offset: 0x001E58C7
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x06002183 RID: 8579 RVA: 0x001E76EA File Offset: 0x001E58EA
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x06002184 RID: 8580 RVA: 0x001E76F4 File Offset: 0x001E58F4
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

		// Token: 0x06002185 RID: 8581 RVA: 0x001E7896 File Offset: 0x001E5A96
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x04004942 RID: 18754
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x04004943 RID: 18755
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x04004944 RID: 18756
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x04004945 RID: 18757
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x04004946 RID: 18758
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x04004947 RID: 18759
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x04004948 RID: 18760
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x04004949 RID: 18761
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x0400494A RID: 18762
		[SerializeField]
		private Transform m_Target;

		// Token: 0x0400494B RID: 18763
		private AeroplaneController m_AeroplaneController;

		// Token: 0x0400494C RID: 18764
		private float m_RandomPerlin;

		// Token: 0x0400494D RID: 18765
		private bool m_TakenOff;
	}
}
