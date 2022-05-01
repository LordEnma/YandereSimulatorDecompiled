using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000533 RID: 1331
	public class CarSelfRighting : MonoBehaviour
	{
		// Token: 0x060021E8 RID: 8680 RVA: 0x001F2AFB File Offset: 0x001F0CFB
		private void Start()
		{
			this.m_Rigidbody = base.GetComponent<Rigidbody>();
		}

		// Token: 0x060021E9 RID: 8681 RVA: 0x001F2B0C File Offset: 0x001F0D0C
		private void Update()
		{
			if (base.transform.up.y > 0f || this.m_Rigidbody.velocity.magnitude > this.m_VelocityThreshold)
			{
				this.m_LastOkTime = Time.time;
			}
			if (Time.time > this.m_LastOkTime + this.m_WaitTime)
			{
				this.RightCar();
			}
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x001F2B70 File Offset: 0x001F0D70
		private void RightCar()
		{
			base.transform.position += Vector3.up;
			base.transform.rotation = Quaternion.LookRotation(base.transform.forward);
		}

		// Token: 0x04004A99 RID: 19097
		[SerializeField]
		private float m_WaitTime = 3f;

		// Token: 0x04004A9A RID: 19098
		[SerializeField]
		private float m_VelocityThreshold = 1f;

		// Token: 0x04004A9B RID: 19099
		private float m_LastOkTime;

		// Token: 0x04004A9C RID: 19100
		private Rigidbody m_Rigidbody;
	}
}
