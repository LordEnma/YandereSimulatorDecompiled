using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052B RID: 1323
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x060021AC RID: 8620 RVA: 0x001EB817 File Offset: 0x001E9A17
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x060021AD RID: 8621 RVA: 0x001EB83A File Offset: 0x001E9A3A
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x060021AE RID: 8622 RVA: 0x001EB844 File Offset: 0x001E9A44
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

		// Token: 0x060021AF RID: 8623 RVA: 0x001EB9E6 File Offset: 0x001E9BE6
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x040049B9 RID: 18873
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x040049BA RID: 18874
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x040049BB RID: 18875
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x040049BC RID: 18876
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x040049BD RID: 18877
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x040049BE RID: 18878
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x040049BF RID: 18879
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x040049C0 RID: 18880
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x040049C1 RID: 18881
		[SerializeField]
		private Transform m_Target;

		// Token: 0x040049C2 RID: 18882
		private AeroplaneController m_AeroplaneController;

		// Token: 0x040049C3 RID: 18883
		private float m_RandomPerlin;

		// Token: 0x040049C4 RID: 18884
		private bool m_TakenOff;
	}
}
