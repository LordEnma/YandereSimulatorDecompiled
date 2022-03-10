using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052E RID: 1326
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x060021C2 RID: 8642 RVA: 0x001ED283 File Offset: 0x001EB483
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x060021C3 RID: 8643 RVA: 0x001ED2A6 File Offset: 0x001EB4A6
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x060021C4 RID: 8644 RVA: 0x001ED2B0 File Offset: 0x001EB4B0
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

		// Token: 0x060021C5 RID: 8645 RVA: 0x001ED452 File Offset: 0x001EB652
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x040049EF RID: 18927
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x040049F0 RID: 18928
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x040049F1 RID: 18929
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x040049F2 RID: 18930
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x040049F3 RID: 18931
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x040049F4 RID: 18932
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x040049F5 RID: 18933
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x040049F6 RID: 18934
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x040049F7 RID: 18935
		[SerializeField]
		private Transform m_Target;

		// Token: 0x040049F8 RID: 18936
		private AeroplaneController m_AeroplaneController;

		// Token: 0x040049F9 RID: 18937
		private float m_RandomPerlin;

		// Token: 0x040049FA RID: 18938
		private bool m_TakenOff;
	}
}
