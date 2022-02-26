using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052D RID: 1325
	[RequireComponent(typeof(AeroplaneController))]
	public class AeroplaneAiControl : MonoBehaviour
	{
		// Token: 0x060021BC RID: 8636 RVA: 0x001EC8AB File Offset: 0x001EAAAB
		private void Awake()
		{
			this.m_AeroplaneController = base.GetComponent<AeroplaneController>();
			this.m_RandomPerlin = UnityEngine.Random.Range(0f, 100f);
		}

		// Token: 0x060021BD RID: 8637 RVA: 0x001EC8CE File Offset: 0x001EAACE
		public void Reset()
		{
			this.m_TakenOff = false;
		}

		// Token: 0x060021BE RID: 8638 RVA: 0x001EC8D8 File Offset: 0x001EAAD8
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

		// Token: 0x060021BF RID: 8639 RVA: 0x001ECA7A File Offset: 0x001EAC7A
		public void SetTarget(Transform target)
		{
			this.m_Target = target;
		}

		// Token: 0x040049D2 RID: 18898
		[SerializeField]
		private float m_RollSensitivity = 0.2f;

		// Token: 0x040049D3 RID: 18899
		[SerializeField]
		private float m_PitchSensitivity = 0.5f;

		// Token: 0x040049D4 RID: 18900
		[SerializeField]
		private float m_LateralWanderDistance = 5f;

		// Token: 0x040049D5 RID: 18901
		[SerializeField]
		private float m_LateralWanderSpeed = 0.11f;

		// Token: 0x040049D6 RID: 18902
		[SerializeField]
		private float m_MaxClimbAngle = 45f;

		// Token: 0x040049D7 RID: 18903
		[SerializeField]
		private float m_MaxRollAngle = 45f;

		// Token: 0x040049D8 RID: 18904
		[SerializeField]
		private float m_SpeedEffect = 0.01f;

		// Token: 0x040049D9 RID: 18905
		[SerializeField]
		private float m_TakeoffHeight = 20f;

		// Token: 0x040049DA RID: 18906
		[SerializeField]
		private Transform m_Target;

		// Token: 0x040049DB RID: 18907
		private AeroplaneController m_AeroplaneController;

		// Token: 0x040049DC RID: 18908
		private float m_RandomPerlin;

		// Token: 0x040049DD RID: 18909
		private bool m_TakenOff;
	}
}
