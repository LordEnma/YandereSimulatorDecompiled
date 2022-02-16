using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052C RID: 1324
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x060021B3 RID: 8627 RVA: 0x001EBCCB File Offset: 0x001E9ECB
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x060021B4 RID: 8628 RVA: 0x001EBCEE File Offset: 0x001E9EEE
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x060021B5 RID: 8629 RVA: 0x001EBCF8 File Offset: 0x001E9EF8
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

		// Token: 0x060021B6 RID: 8630 RVA: 0x001EBE9A File Offset: 0x001EA09A
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x040049C2 RID: 18882
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x040049C3 RID: 18883
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x040049C4 RID: 18884
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x040049C5 RID: 18885
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x040049C6 RID: 18886
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x040049C7 RID: 18887
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x040049C8 RID: 18888
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x040049C9 RID: 18889
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x040049CA RID: 18890
		[SerializeField]
		private Transform m_Target;

		// Token: 0x040049CB RID: 18891
		private AeroplaneController m_AeroplaneController;

		// Token: 0x040049CC RID: 18892
		private float m_RandomPerlin;

		// Token: 0x040049CD RID: 18893
		private bool m_TakenOff;
	}
}
